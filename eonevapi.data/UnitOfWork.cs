using eonevapi.core.Repositories;
using eonevapi.data.Repositories;

namespace eonevapi.data
{
    public class UnitOfWork : IUnitOfWork
    {
        IEONETApiContext apiContext;
        CategoryRepository categoryRepository;
        EventRepository eventRepository;

        public UnitOfWork(IEONETApiContext context)
        {
            apiContext = context;
            categoryRepository = new CategoryRepository(context);
            eventRepository = new EventRepository(context);

        }

        ICategoryRepository IUnitOfWork.categoryRepository => new CategoryRepository(apiContext);

        IEventRepository IUnitOfWork.eventRepository => new EventRepository(apiContext);

        public void Dispose()
        {
            apiContext.Dispose();
        }
    }
}