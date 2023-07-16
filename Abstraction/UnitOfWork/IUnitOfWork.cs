using Abstraction.Entities;
using Abstraction.Repositories;

namespace Abstraction.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    public IRepository<Person, int> PersonRepository { get; }

    public IRepository<Accreditation, int> AccredetationRepository { get; }

    public IRepository<Address, int> AddressRepository { get; }

    Task CommitAsync();
}
