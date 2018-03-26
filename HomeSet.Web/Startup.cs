using AutoMapper;
using HomeSet.Domain;
using HomeSet.Negocio;
using HomeSet.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeSet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            //});
            services.AddMvc();
            //services.AddEntityFrameworkProxies();
            services.AddAutoMapper(cfg => cfg.AddProfile<Mapeo>());
            services.AddScoped<IRepositorio, HomeContext>();
            services.AddScoped<INegocio, Manager>();
            //services.AddAntiforgery(options =>
            //{
            //    options.HeaderName = "X-XSRF-TOKEN";
            //    options.SuppressXFrameOptionsHeader = false;
            //});
            //services.AddDbContext<HomeContext>();
            //services.AddDataProtection()
            //    .SetDefaultKeyLifetime(TimeSpan.FromDays(14))
            //    .SetApplicationName("HomeSet");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
