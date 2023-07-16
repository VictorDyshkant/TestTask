using Abstraction.Entities;
using Abstraction.Repositories;

namespace Abstraction.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<Person, int> PersonRepository { get; }

    //void BeginTransaction();

    Task CommitAsync();
}
