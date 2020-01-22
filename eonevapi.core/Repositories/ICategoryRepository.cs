using System.Collections.Generic;
using System.Threading.Tasks;
using eonevapi.core.Models;

namespace eonevapi.core.Repositories
{
    //Define available methods for categories, in this case retrieval of all categories only
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
    }
}