using System;
using System.Collections.Generic;

namespace TetBet.Infrastructure.Entities
{
    public class BettingTicket : EntityBase
    {
        public IEnumerable<UserBet> UserBets { get; set; }

        public float Sum { get; set; }
        public DateTime Date { get; set; }

        public Infrastructure.Entities.AccountDetails AccountDetails { get; set; }
        public BettingTicketStatus BettingTicketStatus { get; set; }
    }
}