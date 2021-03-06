using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EntityBase = TetBet.Infrastructure.Entities.EntityBase;

namespace TetBet.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> includeProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
                query = includeProperties(query);

            if (orderBy != null)
                return orderBy(query).ToList();

            try
            {
                return query.ToList();
            }
            catch (Exception)
            {
                return new List<TEntity>();
            }
        }

        public TEntity GetById(object id)
            => _dbSet.FirstOrDefault(entity => entity.Id == (long) id);

        public void Insert(TEntity entity)
            => _context.Add(entity);

        public void InsertBulk(IEnumerable<TEntity> entities)
            => entities.ToList().ForEach(Insert);

        public void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
                _dbSet.Attach(entityToDelete);

            _dbSet.Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            // if (entityToUpdate == null)
            //     throw new ArgumentException("entityToUpdate is null");
            //
            // if (_context.Entry(entityToUpdate).State == EntityState.Detached)
            //     HandleDetached(entityToUpdate);
            //
            // _dbSet.Attach(entityToUpdate);
            // _context.Entry(entityToUpdate).State = EntityState.Modified;

            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public bool IsInserted(TEntity entity)
            => _dbSet.Find(entity.Id) != null;

        private bool HandleDetached(TEntity entity)
        {
            var objectContext = ((IObjectContextAdapter) _context).ObjectContext;
            var entitySet = objectContext.CreateObjectSet<TEntity>();
            var entityKey = objectContext.CreateEntityKey(entitySet.EntitySet.Name, entity);

            object foundSet;

            bool exists = objectContext.TryGetObjectByKey(entityKey, out foundSet);
            
            if (exists)
                objectContext.Detach(foundSet);

            return exists;
        }

        public DbSet<TEntity> DbSet => _dbSet;
    }
}