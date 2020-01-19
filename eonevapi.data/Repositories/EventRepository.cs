using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eonevapi.core.Models;
using eonevapi.core.Repositories;

namespace eonevapi.data.Repositories
{
    public class EventRepository : IEventRepository
    {
        IEONETApiContext apiContext;
        public EventRepository(IEONETApiContext apiContext)
        {
            this.apiContext = apiContext;
        }
        public async Task<IEnumerable<Event>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Event> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Event>> GetFiltered(DateTime start, DateTime end, string status, int category)
        {
            throw new NotImplementedException();
        }
    }
}