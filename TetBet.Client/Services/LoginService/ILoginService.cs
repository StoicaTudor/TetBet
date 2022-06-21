using TetBet.Core.Dtos;

namespace TetBet.Client.Services.LoginService
{
    public interface ILoginService
    {
        long SignIn(LoginDto loginDto);
        long SignUp(LoginDto loginDto);
    }
}