using System;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Entities
{
    public class FootballFixture
    {
        public string SportName { get; set; }
        public string Status { get; set; }
        public string BettingEventLocation { get; set; }
        public DateTime BettingEventDate { get; set; }

        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int FixtureId { get; set; }
        public string LeagueName { get; set; }

        public int GoalsFirstHalfHomeTeam { get; set; }
        public int GoalsSecondHalfHomeTeam { get; set; }

        public int GoalsFirstHalfAwayTeam { get; set; }
        public int GoalsSecondHalfAwayTeam { get; set; }
    }
}