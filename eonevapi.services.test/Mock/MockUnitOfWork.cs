using eonevapi.services;
using eonevapi.core.Repositories;
using System.Collections.Generic;
using eonevapi.core.Models;

namespace eonevapi.services.test.Mock
{
    public class MockUnitOfWork : IUnitOfWork
    {
        IEnumerable<Category> MockCategoryRepository;
        IEnumerable<Event> MockEventRepository;
        public MockUnitOfWork(IEnumerable<Category> expectedCategoryResponse = null, IEnumerable<Event> expectedEventResponse = null)
        {
            this.MockCategoryRepository = expectedCategoryResponse;
            this.MockEventRepository = expectedEventResponse;
        }
        public ICategoryRepository categoryRepository => new MockCategoryRepository(MockCategoryRepository);

        public IEventRepository eventRepository => new MockEventRepository(MockEventRepository);
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}