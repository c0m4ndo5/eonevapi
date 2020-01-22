using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eonevapi.core.Models;

namespace eonevapi.core.Repositories
{
    //Define available methods for events, in this case retrieval only
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event> GetById(string id);
        Task<IEnumerable<Event>> GetFiltered(string status, int days, int category);
    }
}