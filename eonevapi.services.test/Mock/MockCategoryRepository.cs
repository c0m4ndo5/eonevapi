using System.Collections.Generic;
using System.Threading.Tasks;
using eonevapi.core.Models;
using eonevapi.core.Repositories;

namespace eonevapi.services.test.Mock
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> expectedResponse;
        public MockCategoryRepository(IEnumerable<Category> expectedResponse)
        {
            this.expectedResponse = expectedResponse;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return expectedResponse;
        }
    }
}