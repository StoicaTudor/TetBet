using System.Collections.Generic;

namespace TetBet.Infrastructure.Entities
{
    public class GenericBet : EntityBase
    {
        public Sport Sport { get; set; }
        public string Name { get; set; }
        public IEnumerable<Infrastructure.Entities.Bet> Bets { get; set; }
    }
}