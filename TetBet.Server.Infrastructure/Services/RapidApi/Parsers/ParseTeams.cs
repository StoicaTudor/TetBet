using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace APIManager.JSON_Parsers
{
    public struct Team
    {
        public string footballTeamName;
        public string footballTeamStadiumName;
        public string footballTeamManagerName;
        public string footballLeagueID;
        public string rapidAPIID;
    }

    public class ParseTeams
    {
        public List<Team> teamsList = new List<Team>();

        public void parse(string json)
        {
            var myJObject = JObject.Parse(json);

            string response = myJObject.SelectToken("response").ToString();

            JArray a = JArray.Parse(response);

            foreach (JObject o in a.Children<JObject>())
            {
                Team team = new Team();
                team.footballTeamName = o.SelectToken("team").SelectToken("name").ToString();
                team.footballTeamManagerName = "";
                team.footballTeamStadiumName =
                    o.SelectToken("venue").SelectToken("name").ToString().Replace("'", "");
                team.footballLeagueID = "2";
                team.rapidAPIID = o.SelectToken("team").SelectToken("id").ToString();

                teamsList.Add(team);
            }
        }
    }
}