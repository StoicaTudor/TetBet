namespace TetBet.Core.Dtos.GetDtos
{
    public class SportEventBetGetDto
    {
        public long Id { get; set; }

        public BetGetDto Bet { get; set; }
        public float OddValue { get; set; }

        public SportEventGetDto SportEvent { get; set; }
    }
}