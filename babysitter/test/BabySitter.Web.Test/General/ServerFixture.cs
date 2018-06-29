using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Commands;
using BabySitter.Core.BabySitters.Models;
using BabySitter.Core.BabySitters.Shifts;
using BabySitter.Core.BabySitters.Shifts.Commands;
using BabySitter.Core.BabySitters.Shifts.Models;
using BabySitter.Core.General;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NodaTime;

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

        public async Task<SitterModel> AddBabySitter(
            string firstName, 
            string lastName, 
            int? hourlyRate = null,
            int? hourlyRateBetweenBedtimeAndMidnight = null, 
            int? hourlyRateAfterMidnight = null)
        {
            var addArgs = new AddBabySitterArgs(
                firstName, 
                lastName, 
                hourlyRate, 
                hourlyRateBetweenBedtimeAndMidnight,
                hourlyRateAfterMidnight);
            
            using (var client = CreateClient())
            {
                var response = await client.PostJsonAsync("babysitters", addArgs);
                return await client.GetJsonAsync<SitterModel>(response.Headers.Location);
            }
        }

        public async Task UpdateBabySitter(int sitterId, string firstName,
            string lastName,
            int hourlyRate,
            int hourlyRateBetweenBedtimeAndMidnight,
            int hourlyRateAfterMidnight)
        {
            var updateArgs = new UpdateBabySitterArgs(sitterId, firstName, lastName, hourlyRate, hourlyRateBetweenBedtimeAndMidnight, hourlyRateAfterMidnight);
            using (var client = CreateClient())
            {
                await client.PutJsonAsync($"babysitters/{sitterId}", updateArgs);
            }
        }
        
        public async Task<SitterModel[]> GetBabySitters()
        {
            using (var client = CreateClient())
            {
                return await client.GetJsonAsync<SitterModel[]>("babysitters");
            }
        }
        
        public async Task<SitterModel> GetBabySitter(int id)
        {
            using (var client = CreateClient())
            {
                return await client.GetJsonAsync<SitterModel>($"babysitters/{id}");
            }
        }
        
        public async Task<ShiftModel> GetBabySitterShift(int sitterId, int shiftId)
        {
            using (var client = CreateClient())
            {
                return await client.GetJsonAsync<ShiftModel>($"babysitters/{sitterId}/shifts/{shiftId}");
            }
        }

        public async Task EndShift(int sitterId, int shiftId, LocalDateTime endTime)
        {
            var endArgs = new EndShiftArgs(sitterId, shiftId, endTime);
            using (var client = CreateClient())
            {
                await client.PutJsonAsync($"babysitters/{sitterId}/shifts/{shiftId}/endShift", endArgs);
            }
        }

        public async Task<ShiftModel> StartShift(int sitterId, LocalDateTime startTime, LocalDateTime bedTime)
        {
            var startArgs = new StartShiftArgs(sitterId, startTime, bedTime);
            using (var client = CreateClient())
            {
                var response = await client.PostJsonAsync($"babysitters/{sitterId}/startShift", startArgs);
                return await client.GetJsonAsync<ShiftModel>(response.Headers.Location);
            }
        }

        public async Task<ShiftModel[]> GetBabySitterShifts(int sitterId)
        {
            using (var client = CreateClient())
            {
                return await client.GetJsonAsync<ShiftModel[]>($"babysitters/{sitterId}/shifts");
            }
        }

        public void ClearDatabase()
        {
            using (var scope = _server.CreateScope())
            using (var context = scope.GetService<DatabaseContext>())
            {
                foreach (var sitter in context.BabySitters.ToList())
                    context.Remove(sitter);
                context.SaveChanges();
            }
        }

        private void DeleteDatabase()
        {
            using (var scope = _server.CreateScope())
            using (var context = scope.GetService<DatabaseContext>())
                context.Database.EnsureDeleted();
        }
    }
}