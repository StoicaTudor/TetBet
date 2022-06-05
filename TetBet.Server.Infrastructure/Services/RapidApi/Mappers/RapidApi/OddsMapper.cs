using System.Collections.Generic;
using System.Linq;
using TetBet.Infrastructure.Entities;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Mappers.RapidApi
{
    /*
     * I created this, because I do not know how to deal with profile mapper which use other IMappers (dk how to resolve
     * unity container)
     */
    public class OddsMapper
    {
        public IEnumerable<Odd> Map(IEnumerable<Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities.Odd> odds)
            => odds.Select(MapOdd);

        public Odd MapOdd(Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities.Odd odd)
            => new()
            {
                Name = odd.Name,
                Value = float.Parse(odd.Value)
            };
    }
}