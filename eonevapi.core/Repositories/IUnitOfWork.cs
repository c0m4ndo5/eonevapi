using System;

namespace eonevapi.core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository categoryRepository { get; }
        IEventRepository eventRepository { get; }
    }
}