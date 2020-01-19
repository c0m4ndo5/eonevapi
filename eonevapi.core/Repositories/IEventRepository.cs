using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eonevapi.core.Models;

namespace eonevapi.core.Repositories
{
    public interface IEventRepository //: IRepository<Event>
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event> GetById(int id);
        Task<IEnumerable<Event>> GetFiltered(DateTime start, DateTime end, string status, int category);
    }
}