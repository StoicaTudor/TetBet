using System;
using System.Collections.Generic;
using TetBet.Infrastructure.Entities;

namespace TetBet.Core.Dtos.GetDtos
{
    public class SportEventGetDto
    {
        public long Id { get; set; }

        public Sport Sport { get; set; }
        public SportEventStatus SportEventStatus { get; set; }

        public string Location { get; set; }
        public DateTime Date { get; set; }

        public IEnumerable<SportEventBetGetDto> AvailableBets { get; set; }
    }
}