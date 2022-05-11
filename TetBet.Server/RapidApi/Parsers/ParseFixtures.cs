using System;
using System.Collections.Generic;
using APIManager.Database;
using Newtonsoft.Json.Linq;

namespace APIManager.JSON_Parsers
{
    public struct FootballFixture
    {
        // DBEventt
        public string sportName;
        public EventStatuses BettingEventStatuses;
        public string bettingEventLocation;
        public DateTime bettingEventDate;

        // DBFootballEvent
        public int rapidAPITeam0ID;
        public int rapidAPITeam1ID;
        public int rapidAPIFixtureID;
        public string leagueName;

        public int goalsFirstHalfTeam0;
        public int goalsSecondHalfTeam0;
        public int goalsFirstHalfTeam1;
        public int goalsSecondHalfTeam1;
    }

    public class ParseFixtures : IJSONParser
    {
        private List<FootballFixture> _fixtures;

        public void parse(string json)
        {
            _fixtures = new List<FootballFixture>();

            var myJObject = JObject.Parse(json);

            string response = myJObject.SelectToken("response").ToString();

            JArray a = JArray.Parse(response);

            foreach (JObject o in a.Children<JObject>())
            {
                FootballFixture footballFixture = new FootballFixture();

                footballFixture.rapidAPIFixtureID = Int32.Parse(o.SelectToken("fixture").SelectToken("id").ToString());
                footballFixture.bettingEventLocation =
                    o.SelectToken("fixture").SelectToken("venue").SelectToken("name").ToString();
                footballFixture.BettingEventStatuses =
                    rapidAPIFixtureStatusToTETBETStatus(o.SelectToken("fixture").SelectToken("status")
                        .SelectToken("long").ToString());
                footballFixture.bettingEventDate =
                    DateTime.Parse(o.SelectToken("fixture").SelectToken("date").ToString());
                footballFixture.rapidAPITeam0ID =
                    Int32.Parse(o.SelectToken("teams").SelectToken("home").SelectToken("id").ToString());
                footballFixture.rapidAPITeam1ID =
                    Int32.Parse(o.SelectToken("teams").SelectToken("away").SelectToken("id").ToString());
                footballFixture.sportName = "Football";
                footballFixture.leagueName = o.SelectToken("league").SelectToken("name").ToString();

                try
                {
                    int scoreHalftimeHome =
                        Int32.Parse(o.SelectToken("score").SelectToken("halftime").SelectToken("home").ToString());
                    int scoreHalftimeAway =
                        Int32.Parse(o.SelectToken("score").SelectToken("halftime").SelectToken("away").ToString());
                    int scoreFulltimeHome =
                        Int32.Parse(o.SelectToken("score").SelectToken("fulltime").SelectToken("home").ToString());
                    int scoreFulltimeAway =
                        Int32.Parse(o.SelectToken("score").SelectToken("fulltime").SelectToken("away").ToString());

                    footballFixture.goalsFirstHalfTeam0 = scoreHalftimeHome;
                    footballFixture.goalsFirstHalfTeam1 = scoreHalftimeAway;
                    footballFixture.goalsSecondHalfTeam0 = scoreFulltimeHome - scoreHalftimeHome;
                    footballFixture.goalsSecondHalfTeam1 = scoreFulltimeAway - scoreHalftimeAway;
                }
                catch (FormatException formatException)
                {
                    footballFixture.goalsFirstHalfTeam0 = -1;
                    footballFixture.goalsFirstHalfTeam1 = -1;
                    footballFixture.goalsSecondHalfTeam0 = -1;
                    footballFixture.goalsSecondHalfTeam1 = -1;
                }

                _fixtures.Add(footballFixture);
            }
        }

        public List<FootballFixture> GetFixtures()
        {
            return _fixtures;
        }

        private EventStatuses rapidAPIFixtureStatusToTETBETStatus(string rapidAPIStatus)
        {
            switch (rapidAPIStatus)
            {
                case "Match Finished":
                    return EventStatuses.ENDED;

                case "Not Started":
                    return EventStatuses.NOT_STARTED;

                case "First Half":
                case "Second Half":
                    return EventStatuses.IN_PROGRESS;

                default: return EventStatuses.NOT_STARTED;
            }
        }
    }
}