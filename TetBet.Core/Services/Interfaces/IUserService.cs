using TetBet.Core.Dtos;
using TetBet.Core.Dtos.GetDtos;

namespace TetBet.Core.Services.Interfaces
{
    public interface IUserService
    {
        UserGetDto GetUserById(long userId);
    }
}