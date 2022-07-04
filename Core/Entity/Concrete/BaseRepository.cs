using System.Linq.Expressions;
using Core.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Core.Entity.Concrete;

public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity> 
    where TEntity : class, IEntity, new()
    where TContext : DbContext
{
    private readonly TContext _context;

    protected BaseRepository(TContext context)
    {
        _context = context;
    }

    public async Task Create(TEntity entity)
    {
        EntityEntry createdEntity = _context.Entry(entity);
        createdEntity.State = EntityState.Added;
        await _context.SaveChangesAsync();
    }

    public async Task Update(TEntity entity)
    {
        EntityEntry modifiedEntity = _context.Entry(entity);
        modifiedEntity.State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(TEntity entity)
    {
        EntityEntry deletedEntity = _context.Entry(entity);
        deletedEntity.State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public async Task<ICollection<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().Where(predicate).ToListAsync();
    }
}