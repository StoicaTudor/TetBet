using System.Collections.Generic;

namespace TetBet.Data.Entities
{
    public class GenericBet : EntityBase
    {
        public Sport Sport { get; set; }
        public string Name { get; set; }
        public IEnumerable<Bet> Bets { get; set; }
    }
}