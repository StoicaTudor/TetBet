using System;
using System.Linq;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Infrastructure.Services.RapidApi.KeySelector;

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
            string rapidApiRootUrl = _unitOfWork
                .RapidApiConfigData
                .Get(rapidApiConfigData => rapidApiConfigData.Key == "RapidApiRootUrl")
                .First()
                .Value;

            if (rapidApiRootUrl == null)
                throw new Exception("RapidApiRootUrl not found");

            return rapidApiRootUrl;
        }

        public string GetRapidApiHost()
        {
            string rapidApiHost = _unitOfWork
                .RapidApiConfigData
                .Get(rapidApiConfigData => rapidApiConfigData.Key == "RapidApiHost")
                .First()
                .Value;

            if (rapidApiHost == null)
                throw new Exception("RapidApiHost not found");

            return rapidApiHost;
        }

        public string GetRapidApiKey()
            => _keySelector.GetKeyWithMostAvailableCalls();

        public string GetRapidApiHostHeaderName()
        {
            string rapidApiHostHeaderName = _unitOfWork
                .RapidApiConfigData
                .Get(rapidApiConfigData => rapidApiConfigData.Key == "RapidApiHostHeaderName")
                .First()
                .Value;

            if (rapidApiHostHeaderName == null)
                throw new Exception("RapidApiHostHeaderName not found");

            return rapidApiHostHeaderName;
        }

        public string GetRapidApiKeyHeaderName()
        {
            string rapidApiKeyHeaderName = _unitOfWork
                .RapidApiConfigData
                .Get(rapidApiConfigData => rapidApiConfigData.Key == "RapidApiKeyHeaderName")
                .First()
                .Value;

            if (rapidApiKeyHeaderName == null)
                throw new Exception("RapidApiKeyHeaderName not found");

            return rapidApiKeyHeaderName;
        }
    }
}