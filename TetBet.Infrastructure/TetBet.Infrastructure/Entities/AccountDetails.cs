using System;
using System.Collections.Generic;
using TetBet.Data.Entities;

namespace TetBet.Infrastructure.Entities
{
    public class AccountDetails : EntityBase
    {
        public User User { get; set; }

        public DateTime DateRegistered { get; set; }
        public float AccountBalance { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<BettingTicket> BettingTickets { get; set; }
    }
}