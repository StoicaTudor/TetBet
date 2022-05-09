using TetBet.Infrastructure.Persistence.Repositories.Interfaces;
using SportEvent = TetBet.Infrastructure.Entities.SportEvent;

namespace TetBet.Infrastructure.Persistence.Repositories.Implementations
{
    public class SportEventRepository : BaseRepository<SportEvent>
    {
        public SportEventRepository(ApplicationContext context) : base(context)
        {
        }
    }
}