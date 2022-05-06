using System;
using System.Collections.Generic;
using TetBet.Core.Entities;

namespace TetBet.Core.Dtos.User
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