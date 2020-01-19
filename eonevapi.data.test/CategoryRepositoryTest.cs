using System;
using Xunit;
using eonevapi.data.Repositories;
using eonevapi.data.test.Mock;
using System.Text.Json;
using eonevapi.core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace eonevapi.data.test
{
    public class CategoryRepositoryTest
    {
        [Fact]
        public async Task TestGetAllAsync()
        {
            JsonDocument testResponse = JsonDocument.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Mock\\MockCategoryResponse.json"));
            CategoryRepository repository = new CategoryRepository(new MockApiContext(testResponse));

            var result = await repository.GetAll();
            Assert.Equal(2, result.Count());
        }
    }
}
