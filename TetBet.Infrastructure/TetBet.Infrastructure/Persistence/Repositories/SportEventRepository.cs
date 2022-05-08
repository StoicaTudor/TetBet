
using TetBet.Data.Entities;

namespace TetBet.Infrastructure.Persistence.Repositories
{
    public class SportEventRepository : BaseRepository<SportEvent>
    {
        public SportEventRepository(ApplicationContext context) : base(context)
        {
        }
    }
}