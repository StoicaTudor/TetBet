namespace TetBet.Infrastructure.Entities
{
    public class SportEventBet : EntityBase
    {
        public Bet Bet { get; set; }
        public float OddValue { get; set; }

        public SportEvent SportEvent { get; set; }
    }
}