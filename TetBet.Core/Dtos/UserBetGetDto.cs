using TetBet.Core.Entities;

namespace TetBet.Core.Dtos.User
{
    public class UserBetGetDto
    {
        public long Id { get; set; }
        
        public SportEventBet SportEventBet { get; set; }
        public UserBetStatus UserBetStatus{ get; set; }
    }
}