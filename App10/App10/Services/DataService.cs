using App10.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace App10.Services
{
    public class DataService<T> : IDataService<T> where T : class
    {
        private readonly ServiceProvider _ServiceProvider;
        private readonly IHttpClientFactory _HttpClientFactory;
        private readonly HttpClient _HttpClient;

        public DataService()
        {
            _ServiceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
            _HttpClientFactory = _ServiceProvider.GetService<IHttpClientFactory>();
            _HttpClient = _HttpClientFactory.CreateClient();
        }

        /// <summary>
        /// This is a reusable function which retrieves data from a REST endpoint using the IHttpClientFactory.
        /// T will represent an instance of the response object.
        /// </summary>
        /// <param name="url">The [GET] endpoint</param>
        /// <returns>Deserialized data from the endpoint provided.</returns>
        public async Task<T> GetDataAsync(string url)
        {
            var response = await _HttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
            response.EnsureSuccessStatusCode();
            var reponseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(reponseBody);
        }
    }
}
