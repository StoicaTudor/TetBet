using System;
using System.Collections.Generic;
using TetBet.Data.Entities;

namespace TetBet.Infrastructure.Entities
{
    public class BettingTicket : EntityBase
    {
        public IEnumerable<UserBet> UserBets { get; set; }

        public float Sum { get; set; }
        public DateTime Date { get; set; }

        public Infrastructure.Entities.AccountDetails AccountDetails { get; set; }
        public BettingTicketType BettingTicketType { get; set; }
    }
}