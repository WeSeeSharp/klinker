using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using BabySitter.Core.Storage;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

        public T Add<T>(T entity)
            where T : class
        {
            using (var scope = _server.CreateScope())
            using (var context = scope.GetService<BabySitterContext>())
            {
                context.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public void ClearDatabase()
        {
            using (var scope = _server.CreateScope())
            using (var context = scope.GetService<BabySitterContext>())
            {
                context.BabySitters
                    .ToList()
                    .ForEach(b => context.Remove(b));
                context.SaveChanges();
            }
        }

        private void DeleteDatabase()
        {
            using (var scope = _server.CreateScope())
            using (var context = scope.GetService<BabySitterContext>())
                context.Database.EnsureDeleted();
        }
    }
}