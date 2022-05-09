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
    public class SportEntity : Infrastructure.Entities.EntityBase
    {
        public string Name { get; set; }
        public Infrastructure.Entities.Country Country { get; set; }
        public string HomeStadium { get; set; }
        
        public IEnumerable<SportRelatedHuman> Team;
        public IEnumerable<SportRelatedHuman> Staff;
    }
}