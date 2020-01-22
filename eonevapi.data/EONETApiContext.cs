using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace eonevapi.data
{
    //This interface/class is responsible for dealing with the specific logic of calling an API
    //If the technology changes or specific requirements such as headers and authentication change,
    //this class needs to be updated
    public interface IEONETApiContext : IDisposable
    {
        Task<JsonDocument> CallAPI(string endpoint);
    }
    public class EONETApiContext : IEONETApiContext
    {
        HttpClient client;
        string baseUrl;
        public EONETApiContext(HttpMessageHandler messageHandler, string baseUrl)
        {
            client = new HttpClient(messageHandler);
            this.baseUrl = baseUrl;
        }
        public async Task<JsonDocument> CallAPI(string endpoint)
        {
            var result = await client.GetAsync(baseUrl + endpoint);
            var stringContent = await result.Content.ReadAsStringAsync();
            return JsonDocument.Parse(stringContent);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}