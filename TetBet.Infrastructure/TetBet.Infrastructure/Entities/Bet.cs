namespace TetBet.Infrastructure.Entities
{
    public class Bet : EntityBase
    {
        public string BetName { get; set; }
        
        public long RapidApiId { get; set; }
    }
}
