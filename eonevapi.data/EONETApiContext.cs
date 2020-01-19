using System;
using System.Net.Http;
using System.Text.Json;

namespace eonevapi.data
{
    public interface IEONETApiContext : IDisposable
    {
        JsonDocument CallAPI(string endpoint);
    }
    public class EONETApiContext : IEONETApiContext
    {
        HttpClient client;
        public EONETApiContext(HttpMessageHandler messageHandler)
        {
            client = new HttpClient(messageHandler);
        }
        public JsonDocument CallAPI(string endpoint)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}