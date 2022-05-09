namespace TetBet.Client.Application.Services.Interfaces
{
    public interface ILoginService
    {
        bool SignIn();
        void SignUp();
    }
}