using System.Linq;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Infrastructure.Services.RapidApi.KeySelector;
using TetBet.Server.Infrastructure.Services.RapidApi.RequestService.Exceptions;

namespace TetBet.Server.Infrastructure.Services.RapidApi.RequestService
{
    // !!!!!!!!!!!! USE RapidApiConfigDataType
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKeySelector _keySelector;

        public RequestService(IUnitOfWork unitOfWork, IKeySelector keySelector)
        {
            _unitOfWork = unitOfWork;
            _keySelector = keySelector;
        }

        public string GetRapidApiRootUrl()
        {
            // TODO: implement this Get -> var client = new RestClient("https://api-football-v1.p.rapidapi.com/v3/odds/bets");
            string rapidApiRootUrl = _unitOfWork
                .RapidApiConfigData
                .Get()
                .First()
                .Value;

            if (rapidApiRootUrl == null)
            {
                throw new RapidApiRootUrlNotFoundException();
            }

            return rapidApiRootUrl;
        }

        public string GetRapidApiHost()
        {
            // TODO: implement this Get -> request.AddHeader("X-RapidAPI-Host", "api-football-v1.p.rapidapi.com");
            string rapidApiHost = _unitOfWork
                .RapidApiConfigData
                .Get()
                .First()
                .Value;

            if (rapidApiHost == null)
            {
                throw new RapidApiHostNotFoundException();
            }

            return rapidApiHost;
        }

        public string GetRapidApiKey()
        {
            return _keySelector.GetKeyWithMostAvailableCalls();
        }

        public string GetRapidApiHostHeaderName()
        {
            throw new System.NotImplementedException();
        }

        public string GetRapidApiKeyHeaderName()
        {
            throw new System.NotImplementedException();
        }
    }
}