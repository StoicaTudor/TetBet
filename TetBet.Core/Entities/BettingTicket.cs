using System;
using System.Collections.Generic;

namespace TetBet.Core.Entities
{
    public class BettingTicket
    {
        public long Id { get; set; }

        public IEnumerable<UserBet> UserBets { get; set; }

        public float Sum { get; set; }
        public DateTime Date { get; set; }

        public AccountDetails AccountDetails { get; set; }
        public BettingTicketType BettingTicketType { get; set; }
    }
}