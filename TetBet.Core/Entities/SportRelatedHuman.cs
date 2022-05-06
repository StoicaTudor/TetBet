namespace TetBet.Core.Entities
{
    /*
     * can be a player, a coach, a referee, CEO of FIFA, anything
     */
    public class SportRelatedHuman
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Country Nationality { get; set; }
        public SportRelatedHumanType SportRelatedHumanType { get; set; }
    }
}