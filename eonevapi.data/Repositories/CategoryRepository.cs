using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using eonevapi.core.Models;
using eonevapi.core.Repositories;

namespace eonevapi.data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        IEONETApiContext apiContext;
        public CategoryRepository(IEONETApiContext apiContext)
        {
            this.apiContext = apiContext;
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            JsonDocument result = await apiContext.CallAPI("categories");

            return (IEnumerable<Category>)JsonSerializer.Deserialize(result.RootElement.GetProperty("categories").ToString(),
            typeof(IEnumerable<Category>));
        }
    }
}