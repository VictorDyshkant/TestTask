using Abstraction.Entities;
using Abstraction.Repositories;
using Database.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class GenericRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
{
    private CustomDbContext _dbContext { get; }

    private DbSet<TEntity> _dbSet { get; }

    public GenericRepository(CustomDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public void Delete(TPrimaryKey id)
    {
        TEntity entity = _dbSet.Find(id);
        _dbSet.Remove(entity);
    }

    public Task<List<TEntity>> GetAllAsync()
    {
        return _dbSet.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(TPrimaryKey id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity;
    }

    public void Insert(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
    }
}
