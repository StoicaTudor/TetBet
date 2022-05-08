using System;
using System.Collections.Generic;

namespace TetBet.Data.Entities
{
    public class SportEvent : EntityBase
    {
        public Sport Sport { get; set; }
        public SportEventStatus SportEventStatus { get; set; }

        public string Location { get; set; }
        public DateTime Date { get; set; }

        public IEnumerable<SportEventBet> AvailableBets { get; set; }

        public string SportEventDetails { get; set; }
    }
}