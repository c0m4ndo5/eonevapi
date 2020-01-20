using System;
using Xunit;
using eonevapi.services;
using eonevapi.services.test.Mock;
using System.Collections.Generic;
using System.Linq;
using eonevapi.core.Models;
using System.Threading.Tasks;

namespace eonevapi.services.test
{
    public class CategoryServiceTest
    {
        [Fact]
        public async Task TestGetAllAsync()
        {
            //Only one method to test, simple get all.
            List<Category> categories = new List<Category>(){
                new Category(){
                    id=1
                },
                new Category(){
                    id=2
                }
            };
            MockUnitOfWork mockUnitOfWork = new MockUnitOfWork(categories);
            CategoryService service = new CategoryService(mockUnitOfWork);
            var result = await service.GetAllCategories();
            Assert.Equal(2, result.Count());
        }
    }
}
