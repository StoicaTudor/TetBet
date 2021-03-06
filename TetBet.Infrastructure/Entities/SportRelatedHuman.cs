namespace TetBet.Infrastructure.Entities
{
    /*
     * can be a player, a coach, a referee, CEO of FIFA, anything
     */
    public class SportRelatedHuman : EntityBase
    {
        public string Name { get; set; }
        public long NationalityId { get; set; }
        public Country Nationality { get; set; }
        public SportRelatedHumanType SportRelatedHumanType { get; set; }

        public long RapidApiId { get; set; }
    }
}