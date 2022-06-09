using System.Collections.Generic;

namespace TetBet.Infrastructure.Entities
{
    public class SportEventBet : EntityBase
    {
        public Bet Bet { get; set; }
        public ICollection<Odd> Odds { get; set; }

        public long SportEventId { get; set; }
        public SportEvent SportEvent { get; set; }
    }
}