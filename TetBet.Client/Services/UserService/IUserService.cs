using TetBet.Core.Dtos.GetDtos;

namespace TetBet.Client.Services.UserService
{
    public interface IUserService
    {
        UserGetDto GetUserById(long userId);
    }
}