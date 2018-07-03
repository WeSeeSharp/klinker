using System;
using System.Net.Http;
using BabySitter.Core.General;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace BabySitter.Web.Test.General
{
    public class ServerFixture : IDisposable
    {
        private readonly TestServer _server;

        public ServerFixture()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>());
        }

        public HttpClient CreateClient()
        {
            return _server.CreateClient();
        }
        
        public void Dispose()
        {
            DeleteDatabase();
            _server.Dispose();
        }

        private void DeleteDatabase()
        {
            using (var scope = _server.CreateScope())
            using (var context = scope.GetService<DatabaseContext>())
                context.Database.EnsureDeleted();
        }
    }
}