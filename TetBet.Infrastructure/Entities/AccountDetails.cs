using System;
using System.Collections.Generic;

namespace TetBet.Infrastructure.Entities
{
    public class AccountDetails : EntityBase
    {
        public DateTime DateRegistered { get; set; }
        public float AccountBalance { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<BettingTicket> BettingTickets { get; set; }
    }
}