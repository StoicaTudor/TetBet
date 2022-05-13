using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities;
using TetBet.Server.Infrastructure.Services.RapidApi.Parsers;

namespace TetBet.Server.Infrastructure.Tests.ServiceTests.RapidApiTests.FetchersTests
{
    public class FixturesTest
    {
        private readonly string _testDataDirectory = Directory.GetCurrentDirectory() +
                                                     "/../../../../TetBet.Server.Infrastructure/Tests/ServiceTests/RapidApiTests/FetchersTests/ResponseSamples/";

        private readonly IJsonResponseParser<ApiFixture> _fixturesJsonParser = new FixturesJsonParser();

        [Test]
        public void BigDataCheckIfDataPresent()
        {
            string fixturesSample = File.ReadAllText(_testDataDirectory + "FixturesBigData.json");

            Assert.AreEqual(380, _fixturesJsonParser.Parse(fixturesSample).Count());
        }
    }
}