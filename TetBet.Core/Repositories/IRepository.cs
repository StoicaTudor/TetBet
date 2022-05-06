using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TetBet.Core.Repositories
{
    public interface IRepository<TEntity>
    {
        void Delete(TEntity entity);
        void Delete(object id);

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetById(object id);
        bool IsInserted(TEntity entity);

        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
}