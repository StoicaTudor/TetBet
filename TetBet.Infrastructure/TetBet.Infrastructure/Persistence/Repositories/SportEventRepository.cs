
using TetBet.Data.Entities;
using SportEvent = TetBet.Infrastructure.Entities.SportEvent;

namespace TetBet.Infrastructure.Persistence.Repositories
{
    public class SportEventRepository : BaseRepository<SportEvent>
    {
        public SportEventRepository(ApplicationContext context) : base(context)
        {
        }
    }
}