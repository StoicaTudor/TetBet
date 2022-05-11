using TetBet.Infrastructure.Entities;

namespace TetBet.Core.BusinessRules.Interfaces
{
    public interface IBettingTicketService
    {
        BettingTicket GetEmptyBettingTicket(AccountDetails accountDetails);
    }
}