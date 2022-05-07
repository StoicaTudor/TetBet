using TetBet.Core.Entities;

namespace TetBet.Core.Dtos
{
    public class UserBetGetDto
    {
        public long Id { get; set; }
        
        public SportEventBet SportEventBet { get; set; }
        public UserBetStatus UserBetStatus{ get; set; }
    }
}