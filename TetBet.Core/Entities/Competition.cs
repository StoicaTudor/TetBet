using System.Collections.Generic;

namespace TetBet.Core.Entities
{
    public class Competition
    {
        public long Id { get; set; }

        public string Season { get; set; }
        public string Name { get; set; }

        public Sport Sport { get; set; }
        public Country Country { get; set; }

        public IEnumerable<SportEntity> SportEntities { get; set; }
    }
}