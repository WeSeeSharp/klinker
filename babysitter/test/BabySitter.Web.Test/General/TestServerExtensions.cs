using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace BabySitter.Web.Test.General
{
    public static class TestServerExtensions
    {
        public static IServiceScope CreateScope(this TestServer server)
        {
            return server.Host.Services.CreateScope();
        }
    }
}