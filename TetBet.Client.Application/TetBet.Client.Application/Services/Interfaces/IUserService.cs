using TetBet.Core.Dtos.GetDtos;

namespace TetBet.Client.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserGetDto GetUserById(long userId);
    }
}