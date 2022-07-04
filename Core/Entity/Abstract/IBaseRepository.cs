using System.Linq.Expressions;

namespace Core.Entity.Abstract;

public interface IBaseRepository<TEntity> where TEntity : class, IEntity, new()
{
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    TEntity Get(Expression<Func<TEntity, bool>> predicate);
    ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
}