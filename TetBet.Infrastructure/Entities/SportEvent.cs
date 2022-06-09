using System;
using System.Collections.Generic;

namespace TetBet.Infrastructure.Entities
{
    public class SportEvent : EntityBase
    {
        public long CompetitionId { get; set; }
        public Competition Competition { get; set; }
        public SportEventStatus Status { get; set; }

        public string Location { get; set; }
        public DateTime Date { get; set; }

        public ICollection<SportEventBet> AvailableBets { get; set; }

        public string SportEventDetails { get; set; }

        public long RapidApiId { get; set; }
    }
}