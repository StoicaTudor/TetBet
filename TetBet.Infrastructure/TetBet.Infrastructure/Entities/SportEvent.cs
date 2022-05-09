using System;
using System.Collections.Generic;
using TetBet.Data.Entities;

namespace TetBet.Infrastructure.Entities
{
    public class SportEvent : Infrastructure.Entities.EntityBase
    {
        public Infrastructure.Entities.Sport Sport { get; set; }
        public SportEventStatus SportEventStatus { get; set; }

        public string Location { get; set; }
        public DateTime Date { get; set; }

        public IEnumerable<SportEventBet> AvailableBets { get; set; }

        public string SportEventDetails { get; set; }
    }
}