namespace TetBet.Server.Infrastructure.Services.RapidApi.RequestService
{
    public interface IRequestService
    {
        string GetRapidApiRootUrl();
        string GetRapidApiHost();
        string GetRapidApiKey();
        string GetRapidApiHostHeaderName();
        string GetRapidApiKeyHeaderName();
    }
}