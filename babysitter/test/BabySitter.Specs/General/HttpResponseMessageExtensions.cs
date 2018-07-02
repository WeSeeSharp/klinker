using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BabySitter.Specs.General
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}