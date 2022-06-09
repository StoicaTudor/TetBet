using System;
using System.Collections.Generic;

namespace TetBet.Infrastructure.Entities
{
    public class BettingTicket : EntityBase
    {
        public ICollection<UserBet> UserBets { get; set; }

        public float Sum { get; set; }
        public DateTime Date { get; set; }

        public long AccountDetailsId { get; set; }
        public AccountDetails AccountDetails { get; set; }
        public BettingTicketStatus BettingTicketStatus { get; set; }
    }
}