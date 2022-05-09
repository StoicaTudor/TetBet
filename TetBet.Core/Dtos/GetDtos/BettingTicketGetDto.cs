using System;
using System.Collections.Generic;
using TetBet.Data.Entities;

namespace TetBet.Core.Dtos.GetDtos
{
    public class BettingTicketGetDto
    {
        public long Id { get; set; }
        public IEnumerable<UserBetGetDto> UserBets { get; set; }
        public float Sum { get; set; }
        public DateTime Date { get; set; }
        public BettingTicketType BettingTicketType { get; set; }
    }
}