using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eonevapi.core.Models;
using eonevapi.core.QueryOptions;

namespace eonevapi.core.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetById(int id);
        Task<IEnumerable<Event>> GetFiltered(EventQueryOptions queryOptions);
    }
}