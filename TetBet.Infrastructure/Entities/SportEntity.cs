using System.Collections.Generic;

namespace TetBet.Infrastructure.Entities
{
    /*
     * can be a solo tennis player,
     * a double tennis team,
     * a football/basketball/handball team,
     * a solo chess player,
     * anything which is eligible to participate in a competition of any kind
     */
    public class SportEntity : EntityBase
    {
        public string Name { get; set; }
        public long CountryId { get; set; }
        public Country Country { get; set; }
        public string HomeStadium { get; set; }

        public IEnumerable<SportRelatedHuman> Team { get; set; }
        public IEnumerable<SportRelatedHuman> Staff { get; set; }

        public IEnumerable<Competition> Competitions { get; set; }

        public long RapidApiId { get; set; }
    }
}