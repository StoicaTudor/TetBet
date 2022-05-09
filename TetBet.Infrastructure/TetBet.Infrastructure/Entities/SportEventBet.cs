namespace TetBet.Infrastructure.Entities
{
    public class SportEventBet : Infrastructure.Entities.EntityBase
    {
        public Infrastructure.Entities.Bet Bet { get; set; }
        public float OddValue { get; set; }

        public Infrastructure.Entities.SportEvent SportEvent { get; set; }
    }
}