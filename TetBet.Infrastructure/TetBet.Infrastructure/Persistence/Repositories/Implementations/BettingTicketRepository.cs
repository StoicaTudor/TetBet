using TetBet.Infrastructure.Persistence.Repositories.Interfaces;
using BettingTicket = TetBet.Infrastructure.Entities.BettingTicket;

namespace TetBet.Infrastructure.Persistence.Repositories.Implementations
{
    public class BettingTicketRepository : BaseRepository<BettingTicket>
    {
        public BettingTicketRepository(ApplicationContext context) : base(context)
        {
        }
    }
}