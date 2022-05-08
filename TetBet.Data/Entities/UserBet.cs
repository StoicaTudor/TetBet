namespace TetBet.Data.Entities
{
    public class UserBet : EntityBase
    {
        public SportEventBet SportEventBet { get; set; }
        public UserBetStatus UserBetStatus{ get; set; }
    }
}