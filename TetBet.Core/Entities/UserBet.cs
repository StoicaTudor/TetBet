namespace TetBet.Core.Entities
{
    public class UserBet
    {
        public long Id { get; set; }
        
        public SportEventBet SportEventBet { get; set; }
        public UserBetStatus UserBetStatus{ get; set; }
    }
}