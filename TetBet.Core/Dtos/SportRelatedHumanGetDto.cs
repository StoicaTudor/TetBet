using TetBet.Core.Entities;

namespace TetBet.Core.Dtos
{
    public class SportRelatedHumanGetDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CountryGetDto Nationality { get; set; }
        public SportRelatedHumanType SportRelatedHumanType { get; set; }
    }
}