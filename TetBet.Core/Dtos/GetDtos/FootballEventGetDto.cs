namespace TetBet.Core.Dtos.GetDtos
{
    public class FootballEventGetDto : SportEventGetDto
    {
        public long FootballEventId { get; set; }

        public SportEntityGetDto HomeTeam { get; set; }
        public SportEntityGetDto AwayTeam { get; set; }
        public CompetitionGetDto Competition { get; set; }

        public int GoalsHomeTeamFirstHalf { get; set; }
        public int GoalsHomeTeamSecondHalf { get; set; }
        
        public int GoalsAwayTeamFirstHalf { get; set; }
        public int GoalsAwayTeamSecondHalf { get; set; }
    }
}