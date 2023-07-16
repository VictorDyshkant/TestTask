using Abstraction.Entities;

namespace Abstraction.Repositories;

public interface IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
{
    Task<List<TEntity>> GetAllAsync();

    Task<TEntity> GetByIdAsync(TPrimaryKey id);

    void Insert(TEntity entity);

    void Update(TEntity entity);

    void Delete(TPrimaryKey id);
}