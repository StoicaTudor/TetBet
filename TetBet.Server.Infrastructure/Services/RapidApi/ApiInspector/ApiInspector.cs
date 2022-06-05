using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using RestSharp;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;

namespace TetBet.Server.Infrastructure.Services.RapidApi.ApiInspector
{
    public class ApiInspector : IApiInspector
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApiInspector(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Inspect(IRestResponse response)
        {
            // CheckForResponseErrors(response);
            UpdateRapidApiKey(response);
        }

        private void UpdateRapidApiKey(IRestResponse response)
        {
            RapidApiKey rapidApiKey = GetLastUsedRapidApiKey();
            rapidApiKey.RemainingCalls = GetRemainingCalls(response);
            rapidApiKey.LastUpdateDate = DateTime.Now;

            _unitOfWork
                .RapidApiKey
                .Update(rapidApiKey);

            _unitOfWork.Commit();
        }

        private RapidApiKey GetLastUsedRapidApiKey()
        {
            // get last used rapid api key

            // TODO -> implement Get() here
            string key = _unitOfWork
                .RapidApiConfigData
                .Get()
                .First()
                .Value;

            // based on the last used rapid api key, get the RapidApiKey object from db
            // TODO -> implement Get() here using key
            return _unitOfWork
                .RapidApiKey
                .Get()
                .First();
        }

        private int GetRemainingCalls(IRestResponse response)
        {
            string remainingCalls = response
                .Headers
                .Where(header => header.Name == "X-RateLimit-requests-Remaining")
                .First()
                .Value
                .ToString();

            return int.Parse(remainingCalls);
        }

        /*
         * this method is currently stupidly implemented,
         * since I did not tested the way response errors/exceptions work in
         * IRestResponse && RapidAPI
         */
        public void CheckForResponseErrors(IRestResponse response)
        {
            if (!response.IsSuccessful)
                throw new Exception("Response not successful exception");

            if (response.ErrorException != null)
                throw response.ErrorException;

            JToken token = JObject
                .Parse(response.Content)
                .SelectToken("message");

            if (token != null)
                token.ToString();
        }
    }
}