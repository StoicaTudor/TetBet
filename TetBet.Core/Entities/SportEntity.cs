using System.Collections.Generic;

namespace TetBet.Core.Entities
{
    /*
     * can be a solo tennis player,
     * a double tennis team,
     * a football/basketball/handball team,
     * a solo chess player,
     * anything which is eligible to participate in a competition of any kind
     */
    public class SportEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public string HomeStadium { get; set; }
        
        public IEnumerable<SportRelatedHuman> Team;
        public IEnumerable<SportRelatedHuman> Staff;
    }
}