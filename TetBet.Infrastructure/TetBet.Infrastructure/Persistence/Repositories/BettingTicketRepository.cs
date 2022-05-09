
using BettingTicket = TetBet.Infrastructure.Entities.BettingTicket;

namespace TetBet.Infrastructure.Persistence.Repositories
{
    public class BettingTicketRepository : BaseRepository<BettingTicket>
    {
        public BettingTicketRepository(ApplicationContext context) : base(context)
        {
        }
    }
}