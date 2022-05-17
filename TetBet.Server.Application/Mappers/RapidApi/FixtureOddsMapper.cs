using System.Collections.Generic;
using System.Linq;
using TetBet.Server.Dtos;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities;

namespace TetBet.Server.Application.Mappers.RapidApi
{
    /*
     * I created this, because I do not know how to deal with profile mapper which use other IMappers (dk how to resolve
     * unity container)
     */
    public class FixtureOddsMapper
    {
        private const long HardCodedPreferredBookmakerId = 8; //  Bet365 from RapidApi

        public FixtureOddsDto FixtureOddToSportEvent(FixtureOdds fixtureOdds)
        {
            IEnumerable<Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities.Bet> bets = fixtureOdds
                .Bookmakers
                .FirstOrDefault(bookmaker => bookmaker.Id == HardCodedPreferredBookmakerId)
                .Bets;

            return new FixtureOddsDto
            {
                FixtureId = fixtureOdds.Fixture.Id,
                AvailableBets = new SportEventBetMapper().Map(bets)
            };
        }
    }
}