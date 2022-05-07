using System;
using System.Collections.Generic;

namespace TetBet.Core.Dtos
{
    public class AccountDetailsGetDto
    {
        public long AccountDetailsId { get; set; }
        public DateTime DateRegistered { get; set; }
        public float AccountBalance { get; set; }
        public IEnumerable<TransactionGetDto> Transactions { get; set; }
        public IEnumerable<BettingTicketGetDto> BettingTickets { get; set; }
    }
}