namespace TetBet.Core.Entities
{
    public class SportEventBet
    {
        public long Id { get; set; }

        public Bet Bet { get; set; }
        public float OddValue { get; set; }

        public SportEvent SportEvent { get; set; }
    }
}