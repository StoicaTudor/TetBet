using System;
using TetBet.Infrastructure.Entities;

namespace TetBet.Core.BusinessRules.BettingTicketService
{
    public class BettingTicketService : IBettingTicketService
    {
        public BettingTicket GetEmptyBettingTicket(AccountDetails accountDetails)
        {
            return new BettingTicket
            {
                Date = DateTime.Now,
                BettingTicketStatus = BettingTicketStatus.NotSubmitted,
                Sum = 0,
                AccountDetails = accountDetails
            };
        }
    }
}