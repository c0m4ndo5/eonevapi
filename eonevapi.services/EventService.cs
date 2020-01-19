using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eonevapi.core.Models;
using eonevapi.core.QueryOptions;
using eonevapi.core.Services;

namespace eonevapi.services
{
    public class EventService : IEventService
    {
        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public async Task<Event> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Event>> GetFiltered(EventQueryOptions queryOptions)
        {
            throw new NotImplementedException();
        }
    }
}