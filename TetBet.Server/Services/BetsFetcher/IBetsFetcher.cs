using System.Collections.Generic;
using TetBet.Infrastructure.Entities;

namespace TetBet.Server.Services.BetsFetcher
{
    public interface IBetsFetcher
    {
        IEnumerable<GenericBet> Fetch();
    }
}