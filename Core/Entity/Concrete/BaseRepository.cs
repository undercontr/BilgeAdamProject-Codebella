using System.Linq.Expressions;
using Core.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Core.Entity.Concrete;

public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity> 
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
{
    private readonly TContext context;

    public BaseRepository(TContext context)
    {
        this.context = context;
    }

    public async Task Create(TEntity entity)
    {
        EntityEntry createdEntity = context.Entry(entity);
        createdEntity.State = EntityState.Added;
        await context.SaveChangesAsync();
    }

    public async Task Update(TEntity entity)
    {
        EntityEntry modifiedEntity = context.Entry(entity);
        modifiedEntity.State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task Delete(TEntity entity)
    {
        EntityEntry deletedEntity = context.Entry(entity);
        deletedEntity.State = EntityState.Deleted;
        await context.SaveChangesAsync();
    }

    public async Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate)
    {
        return await context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public async Task<ICollection<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
    {
        return await context.Set<TEntity>().Where(predicate).ToListAsync();
    }
}