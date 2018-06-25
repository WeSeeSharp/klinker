using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;

namespace BabySitter.Web.Test
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostJsonAsync<T>(this HttpClient client, string url, T body)
        {
            var json = JsonConvert.SerializeObject(body, new JsonSerializerSettings().ConfigureForNodaTime(DateTimeZoneProviders.Tzdb));
            return client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
        }
    }
}