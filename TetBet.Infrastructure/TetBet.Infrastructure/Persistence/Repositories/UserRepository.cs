using User = TetBet.Infrastructure.Entities.User;

namespace TetBet.Infrastructure.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}