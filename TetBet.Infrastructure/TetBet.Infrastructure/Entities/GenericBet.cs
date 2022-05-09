using System.Collections.Generic;
using TetBet.Data.Entities;

namespace TetBet.Infrastructure.Entities
{
    public class GenericBet : Infrastructure.Entities.EntityBase
    {
        public Sport Sport { get; set; }
        public string Name { get; set; }
        public IEnumerable<Infrastructure.Entities.Bet> Bets { get; set; }
    }
}