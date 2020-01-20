using System.Collections.Generic;
using System.Threading.Tasks;
using eonevapi.core.Models;
using eonevapi.core.Repositories;
using System.Linq;

namespace eonevapi.services.test.Mock
{
    public class MockEventRepository : IEventRepository
    {
        public IEnumerable<Event> expectedResponse;
        public MockEventRepository(IEnumerable<Event> expectedResponse)
        {
            this.expectedResponse = expectedResponse;
        }
        public async Task<IEnumerable<Event>> GetAll()
        {
            return expectedResponse;
        }

        public async Task<Event> GetById(string id)
        {
            return expectedResponse.FirstOrDefault(e => e.id == id);
        }

        public async Task<IEnumerable<Event>> GetFiltered(string status, int days, int category)
        {
            return expectedResponse;
        }
    }
}