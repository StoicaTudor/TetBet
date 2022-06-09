using System.Collections.Generic;
using TetBet.Infrastructure.Entities;

namespace TetBet.Server.Infrastructure.Services.RapidApi.ApiInteractor
{
    public interface IApiInteractor
    {
        public IEnumerable<SportEntity> GetTeams(long leagueId, int season);
        public IEnumerable<SportEvent> GetSportEvents(long leagueId, int season);
    }
}