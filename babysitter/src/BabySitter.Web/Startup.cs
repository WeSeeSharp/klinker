using BabySitter.Core;
using BabySitter.Core.BabySitters;
using BabySitter.Core.BabySitters.Shifts.Services;
using BabySitter.Core.General;
using BabySitter.Web.General;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using NodaTime.Serialization.JsonNet;

namespace BabySitter.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o =>
                o.AddDefaultPolicy(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials()));
            services.AddMvc(o =>
                {
                    o.Filters.Add<NullToNotFoundFilter>();
                    o.Filters.Add<ValidationExceptionFilterAttribute>();
                    o.Filters.Add<EntityNotFoundExceptionFilterAttribute>();
                })
                .AddJsonOptions(o => o.SerializerSettings.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb));

            services.AddBabySitterServices(o => 
                o.UseNpgsql(
                    _configuration.GetConnectionString("BabySitterDb"), 
                    s => s.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name).UseNodaTime()
                )
            );
            services.AddSpaStaticFiles(config => config.RootPath = "client-app/build");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseCors()
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseSpaStaticFiles();
            
            app.UseMvc();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client-app";
                if (env.IsDevelopment())
                    spa.UseReactDevelopmentServer("start");
            });
            
            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.GetService<DatabaseContext>())
                context.Database.Migrate();            
        }
    }
}