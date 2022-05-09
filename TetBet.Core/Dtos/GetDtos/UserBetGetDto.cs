using TetBet.Infrastructure.Entities;

namespace TetBet.Core.Dtos.GetDtos
{
    public class UserBetGetDto
    {
        public long Id { get; set; }
        
        public SportEventBet SportEventBet { get; set; }
        public UserBetStatus UserBetStatus{ get; set; }
    }
}