using HomeSet.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Configuration;
using System.Linq;

namespace HomeSet.Repositorio
{
    public class HomeContext : DbContext , IRepositorio
    {

        public HomeContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["MysqlDB"].ConnectionString);
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

        private void MapearAssemblyDe<TEntidad>(ModelBuilder modelBuilder, Predicate<Type> incluir, Predicate<Type> excluir)
        {
            var tiposEntidades = typeof(TEntidad).Assembly.GetTypes()
                .Where(x => incluir(x));
            if (excluir != null)
            {
                tiposEntidades = tiposEntidades.Where(x => !excluir(x));
            }

            var metodo = modelBuilder.GetType().GetMethod("Entity");
            foreach (var tipoEntidad in tiposEntidades)
            {
                metodo.MakeGenericMethod(tipoEntidad).Invoke(modelBuilder, null);
            }
        }
    }
}
