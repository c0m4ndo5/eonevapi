using System;

namespace eonevapi.core.Repositories
{
    //Put together available repositories into a unit of work (design pattern)
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository categoryRepository { get; }
        IEventRepository eventRepository { get; }
    }
}