using System;
using System.IO;
using System.Net.Http;
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
            _server.Dispose();
        }
    }
}