using TetBet.Data.Entities;

namespace TetBet.Infrastructure.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}