using BabySitter.Core;
using BabySitter.Web.Storage;
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
            services.AddMvc()
                .AddJsonOptions(o => o.SerializerSettings.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb));

            services.AddDbContext<BabySitterContext>(o =>
                o.UseNpgsql(_configuration.GetConnectionString("BabySitterDb")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.GetService<BabySitterContext>())
                context.Database.Migrate();
            
            app.UseMvc();
        }
    }
}