using RestSharp;

namespace TetBet.Server.RapidApi.ApiInspector
{
    public interface IApiInspector
    {
        void Inspect(IRestResponse response);
    }
}