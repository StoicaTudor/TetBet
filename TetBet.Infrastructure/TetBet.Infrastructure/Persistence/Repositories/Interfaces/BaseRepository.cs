using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EntityBase = TetBet.Infrastructure.Entities.EntityBase;

namespace TetBet.Infrastructure.Persistence.Repositories.Interfaces
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.FirstOrDefault(entity => entity.Id == (long) id);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            if (entityToUpdate == null)
            {
                throw new ArgumentException("entity");
            }

            if (_context.Entry(entityToUpdate).State == EntityState.Detached)
            {
                HandleDetached(entityToUpdate);
            }

            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual bool IsInserted(TEntity entity)
        {
            return _dbSet.Find(entity.Id) != null;
        }

        private bool HandleDetached(TEntity entity)
        {
            var objectContext = ((IObjectContextAdapter) _context).ObjectContext;
            var entitySet = objectContext.CreateObjectSet<TEntity>();
            var entityKey = objectContext.CreateEntityKey(entitySet.EntitySet.Name, entity);

            object foundSet;

            bool exists = objectContext.TryGetObjectByKey(entityKey, out foundSet);
            if (exists)
            {
                objectContext.Detach(foundSet);
            }

            return exists;
        }
    }
}