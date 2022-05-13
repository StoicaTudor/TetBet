using System.Collections.Generic;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Parsers
{
    public interface IJsonResponseParser<TEntity>
    {
        IEnumerable<TEntity> Parse(string response);
    }
}