using System.Collections.Generic;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football.UrlParams
{
    public class GenericUrlParams
    {
        private readonly Dictionary<string, object> _dictionaryUrlParams = new();

        protected void AddUrlParam(string key, object value)
            => _dictionaryUrlParams.Add(key, value);

        public Dictionary<string, object> DictionaryUrlParams => _dictionaryUrlParams;
    }
}