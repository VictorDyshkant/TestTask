using Abstraction.UnitOfWork;
using Database.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Database.UnitOfWork;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly IDbContextFactory<CustomDbContext> _dbContextFactory;

    public UnitOfWorkFactory(IDbContextFactory<CustomDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
    public IUnitOfWork Create()
    {
        return new UnitOfWork(_dbContextFactory);
    }
}
