using HomeSet.Domain.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace HomeSet.Repositorio
{
    public class IdentityContext : IdentityDbContext<Usuario,Rol,int>
    {
        private readonly IConfiguration Configuration;
        public IdentityContext(IConfiguration config) //: base(config)//DbContextOptions<ApplicationDbContext> options
        {
            Configuration = config;
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Configuration["ConnectionStrings:IdentityDB"],b => b.MigrationsAssembly("HomeSet.Web"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Usuario>(entity => entity.Property(m => m.Id)
            //    .HasMaxLength(180));
            //modelBuilder.Entity<Usuario>(entity => entity.Property(m => m.NormalizedEmail)
            //    .HasMaxLength(180));
            //modelBuilder.Entity<Usuario>(entity => entity.Property(m => m.NormalizedUserName)
            //    .HasMaxLength(180));

            //modelBuilder.Entity<Rol>(entity => entity.Property(m => m.Id)
            //    .HasMaxLength(180));
            //modelBuilder.Entity<Rol>(entity => entity.Property(m => m.NormalizedName)
            //    .HasMaxLength(180));

            //modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider)
            //    .HasMaxLength(180));
            //modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey)
            //    .HasMaxLength(180));
            //modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId)
            //    .HasMaxLength(180));

            //modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId)
            //    .HasMaxLength(180));
            //modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId)
            //    .HasMaxLength(180));

            //modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId)
            //    .HasMaxLength(180));
            //modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider)
            //    .HasMaxLength(180));
            //modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name)
            //    .HasMaxLength(180));

            //modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id)
            //    .HasMaxLength(180));
            //modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId)
            //    .HasMaxLength(180));
            //modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id)
            //    .HasMaxLength(180));
            //modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId)
            //    .HasMaxLength(180));
        }        
    }
}
