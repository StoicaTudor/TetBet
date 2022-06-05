using System.Collections.Generic;
using TetBet.Infrastructure.Entities;

namespace TetBet.Server.Infrastructure.Services.RapidApi.ApiInteractor
{
    public interface IApiInteractor
    {
        public IEnumerable<SportEntity> GetTeams(int leagueId, int season);
    }
}