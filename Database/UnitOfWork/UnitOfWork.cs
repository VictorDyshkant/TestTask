using Abstraction.Entities;
using Abstraction.Repositories;
using Abstraction.UnitOfWork;
using Database.Infrastructure;
using Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Database.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly CustomDbContext _dbContext;
    private bool _isDisposed;

    public UnitOfWork(IDbContextFactory<CustomDbContext> dbContextFactory
        //ISessionFactory sessionFactory,
        //Func<ISession, ICategoryRepository> categoryRepositoryFactory,
        //Func<ISession, IProductRepository> productRepositoryFactory,
        //Func<ISession, IStoreRepository> storeRepositoryFactory
        )
    {
        _dbContext = dbContextFactory.CreateDbContext();
        PersonRepository = new GenericRepository<Person, int>(_dbContext);

        //CategoryRepository = categoryRepositoryFactory(_session);
        //ProductRepository = productRepositoryFactory(_session);
        //StoreRepository = storeRepositoryFactory(_session);
    }

    public IRepository<Person, int> PersonRepository {get; }

    //public void BeginTransaction()
    //{
    //    if (_transaction is not null)
    //    {
    //        _transaction.Dispose();
    //    }

    //    _transaction = _session.BeginTransaction();
    //}

    public Task CommitAsync()
    {
        return _dbContext.SaveChangesAsync();
        //if (_transaction is null || !_transaction.IsActive)
        //{
        //    throw new InvalidOperationException("Not possible to commit changes as transaction was not opened or it is inactive.");
        //}

        //try
        //{
        //    await _transaction.CommitAsync();
        //}
        //catch
        //{
        //    await _transaction.RollbackAsync();
        //    throw;
        //}
    }

    public void Dispose()
    {
        if (!_isDisposed)
        {
            //if (_transaction is not null)
            //{
            //    _transaction.Dispose();
            //}

            if (_dbContext is not null)
            {
                _dbContext.Dispose();
            }

            _isDisposed = true;
        }
    }
}
