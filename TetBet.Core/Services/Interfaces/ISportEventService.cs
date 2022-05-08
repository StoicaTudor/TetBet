using System.Collections.Generic;
using TetBet.Core.Dtos;
using TetBet.Core.Dtos.GetDtos;

namespace TetBet.Core.Services.Interfaces
{
    public interface ISportEventService
    {
        IEnumerable<SportEventGetDto> GetNearFutureActiveSportEvents(int nrDays);
        public SportEventGetDto GetSportEventById(long id);
    }
}