using System.Collections.Generic;
using TetBet.Infrastructure.Entities;

namespace TetBet.Server.Dtos
{
    public class FixtureOddsDto
    {
        public long FixtureId { get; set; }
        public IEnumerable<SportEventBet> AvailableBets { get; set; } 
    }
}