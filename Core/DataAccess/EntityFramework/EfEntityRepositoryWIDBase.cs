using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework;

public class EfEntityRepositoryWIDBase<TEntity, TContext> : EfEntityRepositoryBase<TEntity, TContext>, IEntityRepository<TEntity>

    where TEntity : class, IIDEntity, new()
    where TContext : DbContext, new()
{
    public TEntity GetById(int id)
    {
        using (TContext context = new TContext()){

        return context.Set<TEntity>().SingleOrDefault(t => t.Id ==);
        }
    }
}