using System.Collections.Generic;

namespace TetBet.Infrastructure.Entities
{
    public class SportEventBet : EntityBase
    {
        public Bet Bet { get; set; }
        public IEnumerable<Odd> Odds { get; set; }

        public SportEvent SportEvent { get; set; }
    }
}