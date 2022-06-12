namespace TetBet.Infrastructure.Entities
{
    public class Bet : EntityBase
    {
        public string BetName { get; set; }

        public long RapidApiId { get; set; } // actually this is not needed, but I will temporarily let it here
    }
}