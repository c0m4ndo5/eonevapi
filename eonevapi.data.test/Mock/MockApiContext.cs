using System.Text.Json;
using System.Threading.Tasks;

namespace eonevapi.data.test.Mock
{
    public class MockApiContext : IEONETApiContext
    {
        JsonDocument response;
        public MockApiContext(JsonDocument response)
        {
            this.response = response;
        }
        public async Task<JsonDocument> CallAPI(string endpoint)
        {
            return response;
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}