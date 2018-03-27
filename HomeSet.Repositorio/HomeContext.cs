using HomeSet.Domain;
using HomeSet.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;

namespace HomeSet.Repositorio
{
    public class HomeContext : DbContext , IRepositorio
    {
        private readonly IConfiguration Configuration;
        public HomeContext(IConfiguration config)
        {
            Configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySQL(Configuration["ConnectionStrings:MysqlDB"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // No usamos nombres de tablas en plural. Igualmente la pluralización fucniona solo con nombres en ingles.

            //Se mapean todas las entidades bajo el namespace Molinos.Scato.Dominio.Entidades      
            MapearAssemblyDe<Evento>(modelBuilder, x => x.Namespace == typeof(Evento).Namespace, excluir: null);

        }

        public int GuardarCambios()
        {
            return SaveChanges();
        }

        public TEntity Obtener<TEntity>(object id) where TEntity : class
        {
            return Find<TEntity>(id);
            //return Set<TEntity>().Find(id);
        }

        public EntityEntry<TEntity> Agregar<TEntity>(TEntity entidad) where TEntity : class
        {
            return Add(entidad);
        }

        public EntityEntry<TEntity> Remover<TEntity>(object id) where TEntity : class
        {
            return Remover(Obtener<TEntity>(id));
        }

        public EntityEntry<TEntity> Remover<TEntity>(TEntity entidad) where TEntity : class
        {
            return Remove(entidad);
        }

        public EntityEntry<TEntity> Actualizar<TEntity>(TEntity entidad) where TEntity : class
        {
            return Update(entidad);
        }

        public IEnumerable<TEntity> Listar<TEntity>(Expression<Func<TEntity, bool>> condicion = null, int? maxResultados = null) where TEntity : class
        {
            IQueryable<TEntity> resultado = Set<TEntity>();
            if (condicion != null)
            {
                resultado = resultado.Where(condicion);
            }
            return maxResultados.HasValue ? resultado.Take(maxResultados.Value) : resultado;
        }

        public ListaPaginada<TEntity> Listar<TEntity>(Expression<Func<TEntity, bool>> condicion, Paginacion paginacion) where TEntity : class
        {
            IQueryable<TEntity> resultados = Set<TEntity>();//as IQueryable<Evento>;
            if (condicion != null)
            {
                resultados = resultados.Where(condicion);
            }

            int itemsTotales = resultados.Count();

            if (paginacion.OrdenarPor != null)
            {
                resultados.OrderBy<TEntity>(paginacion.OrdenarPor, paginacion.DireccionOrden == DirOrden.Asc);
            }

            var resultados2 = resultados.Skip((paginacion.Pagina - 1) * paginacion.ItemsPorPagina).Take(paginacion.ItemsPorPagina) as IQueryable<Evento>;
            resultados2 = resultados2.Include(s => s.SubCategoria).ThenInclude(s => s.Categoria);
            resultados = resultados2 as IQueryable<TEntity>;
            //resultados = resultados.Include("");
            //var s = GetNaviProps(typeof(TEntity));

            return new ListaPaginada<TEntity>(resultados.ToList(), paginacion.Pagina, paginacion.ItemsPorPagina, itemsTotales);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder);
        //{
        //    //// No usamos nombres de tablas en plural. Igualmente la pluralización fucniona solo con nombres en ingles.
        //    //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        //    ////Se mapean todas las entidades bajo el namespace Molinos.Scato.Dominio.Entidades      
        //    //MapearAssemblyDe<TipoDocumentoIdentidad>(modelBuilder, x => x.Namespace == typeof(TipoDocumentoIdentidad).Namespace,
        //    //    excluir: null);

        //    //// mapeo many-to-many unidireccional con pustos de carga descarga
        //    //modelBuilder.Entity<Recorrido>()
        //    //    .HasMany(r => r.PuestosDeCargaDescargas)
        //    //    .WithMany(); // sin propiedad d enavecacion para el otro lado

        //    //modelBuilder.Entity<MuestraEnvioACamara>()
        //    //    .HasMany(r => r.CaracteristicasDeCalidad)
        //    //    .WithMany()
        //    //    .Map(m =>
        //    //    {
        //    //        m.MapLeftKey("MuestraEnvioACamara_Id");
        //    //        m.MapRightKey("CaracteristicaDeCalidad_Id");
        //    //        m.ToTable("CaracteristicaDeCalidadMuestraEnvioACamara");
        //    //    });
        //}



        //{
        //    "ConnectionStrings": {
        //    "BloggingDatabase": "Server=(localdb)\\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;"
        //},

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddDbContext<BloggingContext>(options =>
        //        options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));
        //}

        private void MapearAssemblyDe<TEntity>(ModelBuilder modelBuilder, Predicate<Type> incluir, Predicate<Type> excluir)
        {
            var tiposEntidades = typeof(TEntity).Assembly.GetTypes()
                .Where(x => incluir(x));
            if (excluir != null)
            {
                tiposEntidades = tiposEntidades.Where(x => !excluir(x));
            }

            var metodo = modelBuilder.GetType().GetMethods().FirstOrDefault(x => x.Name == "Entity");
            //var metodo = modelBuilder.GetType().GetMethod()
            foreach (var tipoEntidad in tiposEntidades)
            {
                metodo.MakeGenericMethod(tipoEntidad).Invoke(modelBuilder, null);
            }
        }

        private static string[] GetNaviProps(Type entityType)
        {
            return entityType.GetProperties()
                             .Where(p => (typeof(IEnumerable).IsAssignableFrom(p.PropertyType) && p.PropertyType != typeof(string)) || p.PropertyType.Namespace == entityType.Namespace)
                             .Select(p => p.Name)
                             .ToArray();
        }
    }
}
