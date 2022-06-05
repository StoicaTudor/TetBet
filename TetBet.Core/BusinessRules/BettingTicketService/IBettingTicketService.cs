
using TetBet.Infrastructure.Entities;

namespace TetBet.Core.BusinessRules.BettingTicketService
{
    public interface IBettingTicketService
    {
        BettingTicket GetEmptyBettingTicket(AccountDetails accountDetails);
    }
}