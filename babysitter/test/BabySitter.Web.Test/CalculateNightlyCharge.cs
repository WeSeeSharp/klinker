﻿using System.Net;
using System.Threading.Tasks;
using BabySitter.Core;
using BabySitter.Web.Test.General;
using Newtonsoft.Json.Linq;
using Xunit;

namespace BabySitter.Web.Test
{
    [Collection(ServerFixtureCollection.Name)]
    public class CalculateNightlyCharge
    {
        private readonly ServerFixture _fixture;

        public CalculateNightlyCharge(ServerFixture fixture)
        {
            _fixture = fixture;
        }
        
        [Fact]
        public async Task ShouldReturnTotalChargeAmount()
        {
            using (var client = _fixture.CreateClient())
            {
                var parameters = new NightlyChargeParameters(
                    "5:00 PM".ToLocalDateTime(),
                    "9:00 PM".ToLocalDateTime(),
                    "12:00 AM".ToLocalDateTime().PlusDays(1));

                var response = await client.PostJsonAsync("babySitters/nightlyCharge", parameters);
                var data = await response.ReadAsJsonAsync<JObject>();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal(72, data.Value<long>("total"));
            }
        }
    }
}