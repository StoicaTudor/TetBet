using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TetBet.Server.Application.Mappers.RapidApi;
using TetBet.Server.Dtos;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities;

namespace TetBet.Server.Application.Tests.Mappers
{
    public class RapidApiMappersTest
    {
        private FixtureOddsMapper _fixtureOddsMapper = new FixtureOddsMapper();
        private FixtureOdds _fixtureOdds;

        [Test]
        public void FixtureOddsProfileTest()
        {
            FixtureOdds fixtureOdds = Mock();

            FixtureOddsDto fixtureOddsDto = _fixtureOddsMapper.FixtureOddToSportEvent(Mock());


            int fixtureOddsOddsListSize = fixtureOdds
                .Bookmakers
                .First()
                .Bets
                .First()
                .Odds
                .Count();


            int fixtureOddsDtoOddsListSize = fixtureOddsDto
                .AvailableBets
                .First()
                .Odds
                .Count();

            Assert.AreEqual(fixtureOddsOddsListSize, fixtureOddsDtoOddsListSize);
        }

        private FixtureOdds Mock()
            => new()
            {
                League = new League
                {
                    Id = 1,
                    Country = "Romania",
                    Name = "Liga 1",
                    Season = 2021
                },
                Fixture = new Fixture
                {
                    Id = 1,
                    Date = DateTime.Now
                },
                Bookmakers = new List<Bookmaker>()
                {
                    new Bookmaker()
                    {
                        Id = 8,
                        Name = "Bet365",
                        Bets = new List<Bet>
                        {
                            new()
                            {
                                Id = 1,
                                Name = "Match Winner",
                                Odds = new List<Odd>
                                {
                                    new()
                                    {
                                        Name = "Home",
                                        Value = "1.73"
                                    },
                                    new()
                                    {
                                        Name = "Draw",
                                        Value = "3.50"
                                    },
                                    new()
                                    {
                                        Name = "Away",
                                        Value = "3.80"
                                    }
                                }
                            },
                            new()
                            {
                                Id = 5,
                                Name = "Goals Over/Under",
                                Odds = new List<Odd>
                                {
                                    new()
                                    {
                                        Name = "Over 3.5",
                                        Value = "2.75"
                                    },
                                    new()
                                    {
                                        Name = "Under 3.5",
                                        Value = "1.39"
                                    }
                                }
                            }
                        }
                    }
                }
            };
    }
}