using System.Collections.Generic;

namespace TetBet.Infrastructure.Entities
{
    public class Competition : EntityBase
    {
        public int Season { get; set; }
        public string Name { get; set; }

        public long SportId { get; set; }
        public Sport Sport { get; set; }
        public long CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<SportEntity> SportEntities { get; set; }
        
        public long RapidApiId { get; set; }
    }
}