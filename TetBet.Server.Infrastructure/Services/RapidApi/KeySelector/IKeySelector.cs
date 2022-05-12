namespace TetBet.Server.Infrastructure.Services.RapidApi.KeySelector
{
    public interface IKeySelector
    {
        string GetKeyWithMostAvailableCalls();
    }
}