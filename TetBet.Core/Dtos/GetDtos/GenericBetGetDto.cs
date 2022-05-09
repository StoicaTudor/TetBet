namespace TetBet.Core.Dtos.GetDtos
{
    public class GenericBetGetDto
    {
        public long Id { get; set; }
        public SportGetDto Sport { get; set; }
        public string Name { get; set; }
    }
}