namespace TetBet.Infrastructure.Entities
{
    public class UserBet : EntityBase
    {
        public long SportEventBetId { get; set; }
        public SportEventBet SportEventBet { get; set; }
        public UserBetStatus UserBetStatus { get; set; }
    }
}