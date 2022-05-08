using System.Collections.Generic;

namespace TetBet.Core.Dtos.GetDtos
{
    public class SportEntityGetDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CountryGetDto Country { get; set; }
        public string HomeStadium { get; set; }
        
        public IEnumerable<SportRelatedHumanGetDto> Team;
        public IEnumerable<SportRelatedHumanGetDto> Staff;
    }
}