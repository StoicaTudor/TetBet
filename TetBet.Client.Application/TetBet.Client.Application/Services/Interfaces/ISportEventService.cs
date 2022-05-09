using System.Collections.Generic;
using TetBet.Core.Dtos.GetDtos;

namespace TetBet.Client.Application.Services.Interfaces
{
    public interface ISportEventService
    {
        IEnumerable<SportEventGetDto> GetNearFutureActiveSportEvents(int nrDays);
        public SportEventGetDto GetSportEventById(long id);
    }
}