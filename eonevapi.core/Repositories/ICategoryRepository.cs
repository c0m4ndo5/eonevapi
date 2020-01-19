using System.Collections.Generic;
using System.Threading.Tasks;
using eonevapi.core.Models;

namespace eonevapi.core.Repositories
{
    public interface ICategoryRepository// : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAll();
    }
}