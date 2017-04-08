using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Blinnikov.Scrapper.Store
{
    public class FirebaseClient : IFirebaseClient
    {
        // https://allora-conjugator.firebaseio.com/messages/-Kh25SFdTETmGoXcfMaj/original.json
        private readonly HttpClient _httpClient;

        public FirebaseClient(string appId)
        {
            this._httpClient = this.ConfigureHttpClient(appId);
        }

        public async Task<T> Save<T>(T item) where T: class
        {
            var request = this.CreateRequest(item);
            var response = await this._httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        private HttpClient ConfigureHttpClient(string appId)
        {
            var basePath = $"https://{appId}.firebaseio.com/";
            var client = new HttpClient();
            client.BaseAddress = new Uri(basePath);
            return client;
        }

        private HttpRequestMessage CreateRequest<T>(T item) where T: class
        {
            string path = "/words.json";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, path);
            var json = JsonConvert.SerializeObject(item);
            request.Content = new StringContent(json);
            return request;
        }
    }
}