using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TetBet.Infrastructure.Entities;

namespace TetBet.Infrastructure.Persistence.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        void Delete(TEntity entity);
        void Delete(object id);

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> includeProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        TEntity GetById(object id);
        bool IsInserted(TEntity entity);

        void Insert(TEntity entity);
        void InsertBulk(IEnumerable<TEntity> entities);
        void Update(TEntity entity);

        public Microsoft.EntityFrameworkCore.DbSet<TEntity> DbSet { get; }
    }
}