using System.Collections.Generic;
using TetBet.Core.Dtos.GetDtos;

namespace TetBet.Client.Services.SportEventService
{
    public interface ISportEventService
    {
        IEnumerable<SportEventGetDto> GetNearFutureActiveSportEvents(int nrDays);
        public SportEventGetDto GetSportEventById(long id);
    }
}