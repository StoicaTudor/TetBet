// using System;
// using System.Collections.Generic;
// using System.Linq;
// using NUnit.Framework;
// using TetBet.Infrastructure.Entities;
// using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
// using TetBet.Server.Dtos;
// using TetBet.Server.Infrastructure.Services.RapidApi.Entities;
// using TetBet.Server.Infrastructure.Services.RapidApi.Entities.ApiFixtureEntities;
// using TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities;
// using TetBet.Server.Infrastructure.Services.RapidApi.Mappers.RapidApi;
// using Unity;
// using Bet = TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities.Bet;
// using Fixture = TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities.Fixture;
// using League = TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities.League;
// using Odd = TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities.Odd;
//
// namespace TetBet.Server.Application.Tests.Mappers
// {
//     public class RapidApiMappersTest
//     {
//         private FixtureOddsMapper _fixtureOddsMapper = new FixtureOddsMapper();
//         private SportEventMapper _sportEventMapper;
//         private FixtureOdds _fixtureOdds;
//         private IUnityContainer _unityContainer;
//
//         [SetUp]
//         public void Setup()
//         {
//             IocConfig.RegisterComponents();
//             _unityContainer = IocConfig.GetConfiguredContainer();
//
//             _sportEventMapper = _unityContainer.Resolve<SportEventMapper>();
//             _sportEventMapper = new SportEventMapper(_unityContainer.Resolve<IUnitOfWork>());
//         }
//         
//         [Test]
//         public void FixtureOddsProfileTest()
//         {
//             FixtureOdds fixtureOdds = MockFixtureOdds();
//
//             FixtureOddsDto fixtureOddsDto = _fixtureOddsMapper.FixtureOddToSportEvent(fixtureOdds);
//             
//             int fixtureOddsOddsListSize = fixtureOdds
//                 .Bookmakers
//                 .First()
//                 .Bets
//                 .First()
//                 .Odds
//                 .Count();
//
//             int fixtureOddsDtoOddsListSize = fixtureOddsDto
//                 .AvailableBets
//                 .First()
//                 .Odds
//                 .Count();
//
//             Assert.AreEqual(fixtureOddsOddsListSize, fixtureOddsDtoOddsListSize);
//         }
//         
//         [Test]
//         public void FixtureProfileTest()
//         {
//             ApiFixture apiFixture = MockApiFixture();
//
//             SportEvent sportEvent = _sportEventMapper.ApiFixtureToSportEvent(apiFixture);
//
//             Assert.IsTrue(true);
//         }
//
//         private FixtureOdds MockFixtureOdds()
//             => new()
//             {
//                 League = new League
//                 {
//                     Id = 1,
//                     Country = "Romania",
//                     Name = "Liga 1",
//                     Season = 2021
//                 },
//                 Fixture = new Fixture
//                 {
//                     Id = 1,
//                     Date = DateTime.Now
//                 },
//                 Bookmakers = new List<Bookmaker>()
//                 {
//                     new Bookmaker()
//                     {
//                         Id = 8,
//                         Name = "Bet365",
//                         Bets = new List<Bet>
//                         {
//                             new()
//                             {
//                                 Id = 1,
//                                 Name = "Match Winner",
//                                 Odds = new List<Odd>
//                                 {
//                                     new()
//                                     {
//                                         Name = "Home",
//                                         Value = "1.73"
//                                     },
//                                     new()
//                                     {
//                                         Name = "Draw",
//                                         Value = "3.50"
//                                     },
//                                     new()
//                                     {
//                                         Name = "Away",
//                                         Value = "3.80"
//                                     }
//                                 }
//                             },
//                             new()
//                             {
//                                 Id = 5,
//                                 Name = "Goals Over/Under",
//                                 Odds = new List<Odd>
//                                 {
//                                     new()
//                                     {
//                                         Name = "Over 3.5",
//                                         Value = "2.75"
//                                     },
//                                     new()
//                                     {
//                                         Name = "Under 3.5",
//                                         Value = "1.39"
//                                     }
//                                 }
//                             }
//                         }
//                     }
//                 }
//             };
//
//         private ApiFixture MockApiFixture()
//             => new()
//             {
//                 Fixture = new Infrastructure.Services.RapidApi.Entities.ApiFixtureEntities.Fixture()
//                 {
//                     Date = DateTime.Now,
//                     Id = 123,
//                     Status = new Status
//                     {
//                         FullName = "Match Finished",
//                         MinutesElapsed = 90,
//                         ShortName = "ME"
//                     },
//                 },
//                 League = new Infrastructure.Services.RapidApi.Entities.ApiFixtureEntities.League()
//                 {
//                     Id = 1,
//                     Country = "England",
//                     Name = "Premier League",
//                     Season = 2022
//                 },
//                 Teams = new Teams
//                 {
//                     HomeTeam = new Infrastructure.Services.RapidApi.Entities.ApiFixtureEntities.Team
//                     {
//                         Id = 1,
//                         Name = "Manchester UTD",
//                         IsWinner = true
//                     },
//                     AwayTeam = new Infrastructure.Services.RapidApi.Entities.ApiFixtureEntities.Team
//                     {
//                         Id = 2,
//                         Name = "Liverpool",
//                         IsWinner = false
//                     }
//                 },
//                 Goals = new Goals
//                 {
//                     HomeTeamGoals = 0,
//                     AwayTeamGoals = 0
//                 },
//                 Score = new Score
//                 {
//                     HalfTimeScore = new RoundScore
//                     {
//                         HomeTeamGoals = 0,
//                         AwayTeamGoals = 0
//                     },
//                     FullTimeScore = new RoundScore
//                     {
//                         HomeTeamGoals = 0,
//                         AwayTeamGoals = 0
//                     }
//                 }
//             };
//     }
// }