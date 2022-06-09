using TetBet.Infrastructure.Entities;

namespace TetBet.Server.Services.BetWinnerProcessor
{
    public interface IBetWinnerProcessor
    {
        public bool IsBetWon(UserBet userBet);
    }
}