using System.IO;
using System.Linq;
using NUnit.Framework;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities;
using TetBet.Server.Infrastructure.Services.RapidApi.Parsers;

namespace TetBet.Server.Infrastructure.Tests.ServiceTests.RapidApiTests.FetchersTests
{
    public class OddsByFixtureTest
    {
        private readonly string _testDataDirectory = Directory.GetCurrentDirectory() +
                                                     "/../../../../TetBet.Server.Infrastructure/Tests/ServiceTests/RapidApiTests/FetchersTests/ResponseSamples/OddsByFixture/";

        private readonly IJsonResponseParser<FixtureOdds> _fixtureOddsJsonParse = new FixtureOddsJsonParser();

        [Test]
        public void BigJsonCheckIfContentExists()
        {
            string oddsByFixtureIdSample = File.ReadAllText(_testDataDirectory + "BigData.json");

            FixtureOdds fixtureOdds = _fixtureOddsJsonParse.Parse(oddsByFixtureIdSample).First();

            Assert.IsNotNull(fixtureOdds.League);
            Assert.IsNotNull(fixtureOdds.Fixture);
            Assert.AreEqual(10, fixtureOdds.Bookmakers.Count());
        }

        [Test]
        public void SmallJsonCheckIfAllDataIsCorrect()
        {
            string oddsByFixtureIdSample = File.ReadAllText(_testDataDirectory + "SmallData.json");

            FixtureOdds fixtureOdds = _fixtureOddsJsonParse.Parse(oddsByFixtureIdSample).First();

            Assert.AreEqual(781, fixtureOdds.League.Id);
            Assert.AreEqual("III Liga - Group 2", fixtureOdds.League.Name);
            Assert.AreEqual("Poland", fixtureOdds.League.Country);

            Assert.AreEqual(764267, fixtureOdds.Fixture.Id);

            Bookmaker bookmaker = fixtureOdds.Bookmakers.First();
            Assert.AreEqual(6, bookmaker.Id);
            Assert.AreEqual("Bwin", bookmaker.Name);
            Assert.AreEqual(5, bookmaker.Bets.Count());

            Bet bet = bookmaker.Bets.First();
            Assert.AreEqual(1, bet.Id);
            Assert.AreEqual("Match Winner", bet.Name);
            Assert.AreEqual(3, bet.Odds.Count());
        }
    }
}