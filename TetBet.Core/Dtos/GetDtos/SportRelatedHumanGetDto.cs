using TetBet.Data.Entities;

namespace TetBet.Core.Dtos.GetDtos
{
    public class SportRelatedHumanGetDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CountryGetDto Nationality { get; set; }
        public SportRelatedHumanType SportRelatedHumanType { get; set; }
    }
}