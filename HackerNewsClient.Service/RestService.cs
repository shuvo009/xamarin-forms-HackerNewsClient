using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HackerNewsClient.Core.Interface;
using Newtonsoft.Json;

namespace HackerNewsClient.Service
{
    public class RestService : IRestService
    {
        private readonly HttpClient _httpClient;

        public RestService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<T> Get<T>(string url)
        {
            var uri = new Uri(url);
            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.StatusCode.ToString());

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
