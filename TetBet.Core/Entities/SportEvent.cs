using System;
using System.Collections.Generic;

namespace TetBet.Core.Entities
{
    public abstract class SportEvent
    {
        public long Id { get; set; }
        
        public Sport Sport { get; set; }
        public SportEventStatus SportEventStatus { get; set; }
        
        public string Location { get; set; }
        public DateTime Date { get; set; }
        
        public IEnumerable<SportEventBet> AvailableBets { get; set; }
    }
}