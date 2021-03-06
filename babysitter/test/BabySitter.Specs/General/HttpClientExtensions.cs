﻿using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;

namespace BabySitter.Specs.General
{
    public static class HttpClientExtensions
    {
        private static readonly JsonSerializerSettings SerializerSettings =
            new JsonSerializerSettings().ConfigureForNodaTime(DateTimeZoneProviders.Tzdb); 
        
        public static Task<HttpResponseMessage> PostJsonAsync<T>(this HttpClient client, string url, T body)
        {
            var json = JsonConvert.SerializeObject(body, SerializerSettings);
            return client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
        }

        public static Task<HttpResponseMessage> PutJsonAsync<T>(this HttpClient client, string url, T body)
        {
            var json = JsonConvert.SerializeObject(body, SerializerSettings);
            return client.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
        }

        public static async Task<T> GetJsonAsync<T>(this HttpClient client, string url)
        {
            var json = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(json, SerializerSettings);
        }

        public static async Task<T> GetJsonAsync<T>(this HttpClient client, Uri uri)
        {
            return await client.GetJsonAsync<T>(uri.ToString());
        }
    }
}