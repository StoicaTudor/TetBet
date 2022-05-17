using System.Collections.Generic;
using System.Linq;
using TetBet.Infrastructure.Entities;

namespace TetBet.Server.Application.Mappers.RapidApi
{
    /*
     * I created this, because I do not know how to deal with profile mapper which use other IMappers (dk how to resolve
     * unity container)
     */
    public class SportEventBetMapper
    {
        private SportEventBet MapSportEventBet(Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities.Bet bet)
            => new()
            {
                Bet = MapBet(bet),
                Odds = new OddsMapper().Map(bet.Odds)
            };

        private Bet MapBet(Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities.Bet bet)
            => new()
            {
                BetName = bet.Name,
                RapidApiId = bet.Id
            };

        public IEnumerable<SportEventBet> Map(IEnumerable<Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities.Bet> bets)
            => bets.Select(MapSportEventBet);
    }
}