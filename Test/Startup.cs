using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog.AspNetCore;
using System;

namespace Test
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
            var connectionString = Configuration["ConnectionString"];
            services.AddIdentityServer(x =>
            {
                x.IssuerUri = "null";
                x.Authentication.CookieLifetime = TimeSpan.FromHours(2);
            })
           .AddDeveloperSigningCredential()
           .AddConfigurationStore<Data.ConfigurationDBContextImpl>(options =>
           {
               options.ConfigureDbContext = builder =>
                 builder.UseOracle(connectionString, opt =>
                 {
                     opt.UseOracleSQLCompatibility("11");
                 });
           })
          .AddOperationalStore<PersistedGrantDbContext>(options =>
          {
              options.ConfigureDbContext = builder =>
              builder.UseOracle(connectionString, opt =>
              {
                  opt.UseOracleSQLCompatibility("11");
              });
          });
            services.AddSingleton<ILoggerFactory>(s => new SerilogLoggerFactory(null, false));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
