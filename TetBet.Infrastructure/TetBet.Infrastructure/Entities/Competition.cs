using System.Collections.Generic;
using TetBet.Data.Entities;

namespace TetBet.Infrastructure.Entities
{
    public class Competition : EntityBase
    {
        public string Season { get; set; }
        public string Name { get; set; }

        public Sport Sport { get; set; }
        public Country Country { get; set; }

        public IEnumerable<SportEntity> SportEntities { get; set; }
    }
}