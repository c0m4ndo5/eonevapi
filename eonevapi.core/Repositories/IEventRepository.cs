using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eonevapi.core.Models;

namespace eonevapi.core.Repositories
{
    public interface IEventRepository //: IRepository<Event>
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event> GetById(string id);
        Task<IEnumerable<Event>> GetFiltered(string status, int days, int category);
    }
}