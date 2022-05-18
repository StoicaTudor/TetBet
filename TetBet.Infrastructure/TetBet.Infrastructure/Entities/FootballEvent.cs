namespace TetBet.Infrastructure.Entities
{
    public class FootballEvent
    {
        public int? HomeTeamGoals { get; set; }
        public int? AwayTeamGoals { get; set; }

        public int? HomeTeamFirstHalfGoals { get; set; }
        public int? AwayTeamFirstHalfGoals { get; set; }

        public int? HomeTeamSecondHalfGoals { get; set; }
        public int? AwayTeamSecondHalfGoals { get; set; }

        public SportEntity HomeTeam { get; set; }
        public SportEntity AwayTeam { get; set; }
    }
}