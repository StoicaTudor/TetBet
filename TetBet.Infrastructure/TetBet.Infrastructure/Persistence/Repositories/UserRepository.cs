using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TetBet.Core.Entities;
using TetBet.Core.Repositories;

namespace TetBet.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public User GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool IsInserted(User entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}