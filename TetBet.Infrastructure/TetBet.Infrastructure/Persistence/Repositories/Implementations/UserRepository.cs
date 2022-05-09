using TetBet.Infrastructure.Persistence.Repositories.Interfaces;
using User = TetBet.Infrastructure.Entities.User;

namespace TetBet.Infrastructure.Persistence.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}