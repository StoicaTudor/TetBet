using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities;
using TetBet.Server.Infrastructure.Services.RapidApi.Parsers.Exceptions;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Parsers
{
    public class TeamsJsonParser : IJsonResponseParser<Team>
    {
        public int LeagueId { get; set; } = 0;
        public int Season { get; set; } = 0;

        public IEnumerable<Team> Parse(string response)
        {
            IEnumerable<Team> teams = new List<Team>();

            if (LeagueId == 0 || Season == 0)
                throw new ParserPropertiesNotSetException();

            JToken dataResponseToken = JObject
                .Parse(response)
                .SelectToken("response");

            if (dataResponseToken == null)
                throw new DataResponseNotExistsException("dataResponseToken is null");

            JArray
                .Parse(dataResponseToken.ToString())
                .Children<JObject>()
                .ToList()
                .ForEach(obj => teams = teams.Append(GetParsedTeam(obj)));

            return teams;
        }

        private Team GetParsedTeam(JObject dataResponseToken)
        {
            JToken teamToken = dataResponseToken.SelectToken("team");
            JToken venueToken = dataResponseToken.SelectToken("venue");

            if (teamToken == null) throw new DataResponseNotExistsException("teamToken is null");
            if (venueToken == null) throw new DataResponseNotExistsException("venueToken is null");

            Team team = new Team();

            try
            {
                team = new Team
                {
                    Id = int.Parse(teamToken.SelectToken("id").ToString()),
                    Name = teamToken.SelectToken("name").ToString(),
                    LeagueId = LeagueId,
                    ManagerName = "",
                    StadiumName = venueToken.SelectToken("name").ToString()
                };
            }
            catch (NullReferenceException nullReferenceException)
            {
                Console.WriteLine(nullReferenceException.StackTrace);
            }

            return team;
        }
    }
}