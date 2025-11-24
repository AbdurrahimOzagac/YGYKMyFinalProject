using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
{
    public virtual void Add(TEntity entity)
    {
        using var context = new TContext();
        context.Set<TEntity>().Add(entity);
        context.SaveChanges();
    }

    public virtual void Delete(TEntity entity)
    {
        using var context = new TContext();
        context.Entry(entity).State = EntityState.Deleted;
        context.SaveChanges();
    }

    public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        using var context = new TContext();
        return context.Set<TEntity>().SingleOrDefault(filter);
    }

    public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
    {
        using var context = new TContext();
        return filter == null
            ? context.Set<TEntity>().ToList()
            : context.Set<TEntity>().Where(filter).ToList();
    }

    public virtual List<TEntity> GetAllByCategory(int categoryId)
    {
        throw new NotSupportedException("Category filtering is not defined for this entity.");
    }

    public virtual void Update(TEntity entity)
    {
        using var context = new TContext();
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }
}
