using BabySitter.Core;
using BabySitter.Core.BabySitters;
using BabySitter.Core.BabySitters.Shifts.Services;
using BabySitter.Core.General;
using BabySitter.Web.General;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddTransient<NightlyChargeCalculator>();
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
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.GetService<DatabaseContext>())
                context.Database.Migrate();
            
            app.UseMvc();
        }
    }
}