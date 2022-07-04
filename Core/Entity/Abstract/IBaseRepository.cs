using System.Linq.Expressions;

namespace Core.Entity.Abstract;

public interface IBaseRepository<TEntity> where TEntity : class, IEntity, new()
{
    Task Create(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
    Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate);
    Task<ICollection<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);
}