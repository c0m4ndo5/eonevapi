using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using eonevapi.data.Repositories;
using eonevapi.data.test.Mock;
using Xunit;

namespace eonevapi.data.test
{
    public class EventRepositoryTest
    {
        [Fact]
        public async Task GetAllTestAsync()
        {
            JsonDocument testResponse = JsonDocument.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Mock\\MockEventsResponse.json"));
            EventRepository repository = new EventRepository(new MockApiContext(testResponse));
            var result = await repository.GetAll();
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetByIdTestAsync()
        {
            JsonDocument testResponse = JsonDocument.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Mock\\MockEventResponse.json"));
            EventRepository repository = new EventRepository(new MockApiContext(testResponse));
            var result = await repository.GetById("TEST");
            Assert.Equal("EONET_4545", result.id);
        }

        [Fact]
        public async Task GetFilteredTestAsync()
        {
            //As this filtering is done on EONET, this simply tests whether the code to make the API call runs with different parameters without errors
            JsonDocument testResponse = JsonDocument.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Mock\\MockEventsResponse.json"));
            EventRepository repository = new EventRepository(new MockApiContext(testResponse));
            var result = await repository.GetFiltered("open");
            Assert.Equal(3, result.Count());

            result = await repository.GetFiltered("open", 20, 8);
            Assert.Equal(3, result.Count());
        }
    }
}
