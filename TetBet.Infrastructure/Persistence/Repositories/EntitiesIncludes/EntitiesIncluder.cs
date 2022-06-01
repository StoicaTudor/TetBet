using System;
using System.Linq;
using System.Linq.Expressions;

namespace TetBet.Infrastructure.Persistence.Repositories.EntitiesIncludes
{
    public abstract class EntitiesIncluder<TEntity>
    {
        public IQueryable<TEntity> IncludeEntities(IQueryable<TEntity> query)
            => SetIncludes(query);

        protected abstract IQueryable<TEntity> SetIncludes(IQueryable<TEntity> query);
    }
}