using TetBet.Core.Dtos.GetDtos;

namespace TetBet.Client.Application.Services.UserService
{
    public interface IUserService
    {
        UserGetDto GetUserById(long userId);
        UserGetDto GetSessionUser();
    }
}