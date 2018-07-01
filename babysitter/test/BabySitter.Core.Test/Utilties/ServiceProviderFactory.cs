using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BabySitter.Core.Test.Utilties
{
    public class ServiceProviderFactory
    {
        public static IServiceProvider Create()
        {
            var services = new ServiceCollection()
                .AddBabySitterServices(o => o.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            return services.BuildServiceProvider();
        }
    }
}