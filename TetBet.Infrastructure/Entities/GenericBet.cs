using System.Collections.Generic;

namespace TetBet.Infrastructure.Entities
{
    public class GenericBet : EntityBase
    {
        public long SportId { get; set; }
        public Sport Sport { get; set; }
        public string Name { get; set; }
        public ICollection<Bet> Bets { get; set; }
    }
}