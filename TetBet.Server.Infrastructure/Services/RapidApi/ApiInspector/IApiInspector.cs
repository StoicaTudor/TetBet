using RestSharp;

namespace TetBet.Server.Infrastructure.Services.RapidApi.ApiInspector
{
    public interface IApiInspector
    {
        void Inspect(IRestResponse response);
    }
}