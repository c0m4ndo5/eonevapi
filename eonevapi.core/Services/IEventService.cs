using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eonevapi.core.Models;
using eonevapi.core.QueryOptions;

namespace eonevapi.core.Services
{
    //Define available service methods for events
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetById(string id);
        Task<IEnumerable<Event>> GetFiltered(EventQueryOptions queryOptions);
    }
}