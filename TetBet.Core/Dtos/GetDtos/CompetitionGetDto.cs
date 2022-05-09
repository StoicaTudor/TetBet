using System.Collections.Generic;

namespace TetBet.Core.Dtos.GetDtos
{
    public class CompetitionGetDto
    {
        public long Id { get; set; }

        public string Season { get; set; }
        public string Name { get; set; }

        public SportGetDto Sport { get; set; }
        public CountryGetDto Country { get; set; }

        public IEnumerable<SportEntityGetDto> SportEntities { get; set; }
    }
}