using Microsoft.EntityFrameworkCore;
using System;

namespace HomeSet.Repositorio
{
    public class HomeContext : DbContext
    {

        public HomeContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
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
    }
}
