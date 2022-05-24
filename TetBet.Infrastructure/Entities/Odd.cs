namespace TetBet.Infrastructure.Entities
{
    public class Odd : EntityBase
    {
        public string Name { get; set; }
        public float Value { get; set; }

        public Bet Bet { get; set; }
    }
}