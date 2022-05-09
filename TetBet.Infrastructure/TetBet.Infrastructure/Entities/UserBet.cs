using TetBet.Data.Entities;

namespace TetBet.Infrastructure.Entities
{
    public class UserBet : Infrastructure.Entities.EntityBase
    {
        public Infrastructure.Entities.SportEventBet SportEventBet { get; set; }
        public UserBetStatus UserBetStatus{ get; set; }
    }
}