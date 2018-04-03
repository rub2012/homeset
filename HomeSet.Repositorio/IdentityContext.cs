using HomeSet.Domain.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HomeSet.Repositorio
{
    public class IdentityContext : IdentityDbContext<Usuario>
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
        }        
    }
}
