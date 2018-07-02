using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace BabySitter.Specs.General
{
    public static class TestServerExtensions
    {
        public static T GetService<T>(this TestServer server)
        {
            return server.Host.Services.GetService<T>();
        }

        public static IServiceScope CreateScope(this TestServer server)
        {
            return server.Host.Services.CreateScope();
        }
    }
}