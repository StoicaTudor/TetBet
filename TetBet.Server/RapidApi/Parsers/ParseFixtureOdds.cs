using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace APIManager.JSON_Parsers
{
    public struct FixtureOdds
    {
        public int fixtureRapidAPIID;
        public int betTypeRapidAPIID;
        public float oddValue;
        public string oddName;
    }

    public class ParseFixtureOdds : IJSONParser
    {
        public List<FixtureOdds> fixturesOddsList;

        public void parse(string json)
        {
            fixturesOddsList = new List<FixtureOdds>();

            var myJObject = JObject.Parse(json);

            string response = myJObject.SelectToken("response").ToString();

            JArray a = JArray.Parse(response);

            foreach (JObject o in a.Children<JObject>())
            {
                // fixtureOdds.rapidAPIFixtureID = Int32.Parse(o.SelectToken("fixture").SelectToken("id").ToString());
                // footballFixture.bettingEventLocation =
                //     o.SelectToken("fixture").SelectToken("venue").SelectToken("name").ToString();
                // footballFixture.BettingEventStatuses =
                //     rapidAPIFixtureStatusToTETBETStatus(o.SelectToken("fixture").SelectToken("status")
                //         .SelectToken("long").ToString());
                // footballFixture.bettingEventDate =
                //     DateTime.Parse(o.SelectToken("fixture").SelectToken("date").ToString());
                // footballFixture.rapidAPITeam0ID =
                //     Int32.Parse(o.SelectToken("teams").SelectToken("home").SelectToken("id").ToString());
                // footballFixture.rapidAPITeam1ID =
                //     Int32.Parse(o.SelectToken("teams").SelectToken("away").SelectToken("id").ToString());
                // footballFixture.sportName = "Football";
                // footballFixture.leagueName = o.SelectToken("league").SelectToken("name").ToString();

                int fixtureRapidAPIID = Int32.Parse(o.SelectToken("fixture").SelectToken("id").ToString());

                string bookmakersResponse = o.SelectToken("bookmakers").ToString();
                JArray bookmakersJArray = JArray.Parse(bookmakersResponse);

                foreach (JObject bookmakerObject in bookmakersJArray.Children<JObject>())
                {
                    string betsResposne = bookmakerObject.SelectToken("bets").ToString();
                    JArray betsJArray = JArray.Parse(betsResposne);

                    foreach (JObject betsObject in betsJArray.Children<JObject>())
                    {
                        string valuesResponse = betsObject.SelectToken("values").ToString();
                        JArray valuesArray = JArray.Parse(valuesResponse);

                        int betTypeRapidAPIID = Int32.Parse(betsObject.SelectToken("id").ToString());

                        foreach (JObject valueObject in valuesArray.Children<JObject>())
                        {
                            FixtureOdds fixtureOdds = new FixtureOdds();

                            fixtureOdds.oddValue = float.Parse(valueObject.SelectToken("odd").ToString());
                            fixtureOdds.oddName = valueObject.SelectToken("value").ToString();
                            fixtureOdds.fixtureRapidAPIID = fixtureRapidAPIID;
                            fixtureOdds.betTypeRapidAPIID = betTypeRapidAPIID;

                            fixturesOddsList.Add(fixtureOdds);
                        }
                    }
                }
            }
        }
    }
}