using System.Collections.Generic;
using TetBet.Infrastructure.Entities;

namespace TetBet.Server.Services.BetsFetcher.Entities
{
    public class ApplicationBets
    {
        public IEnumerable<GenericBet> GenericBets { get; set; }
    }
}