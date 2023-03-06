using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using URLShortner.Models;

namespace URLShortner.Services
{
    public class HttpClientService : HttpClient
    {
        private const string apiKey = "OfV5xcbVy4tWpAKFI0zY7B9MyAA1oSmQ";
        private const string baseURL = "https://api.apilayer.com/short_url/hash";
        private static readonly HttpClientService instance = new HttpClientService();

        static HttpClientService() { }

        private HttpClientService() : base()
        {
            Timeout = TimeSpan.FromMilliseconds(15000);
            MaxResponseContentBufferSize = 256000;
            DefaultRequestHeaders.Add("apikey", apiKey);
        }

        public static HttpClientService Instance
        {
            get
            {
                return instance;
            }
        }

        public async Task<T> PostAsync<T>(T item, string url = null)
        {
            var uri = new Uri(string.Format(baseURL, url));
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(jsonResponse);
            }
            else
            {
                //TODO : Show alert saying something went wrong!
                throw new Exception(response.ReasonPhrase);
            }
            
        }
    }
}

