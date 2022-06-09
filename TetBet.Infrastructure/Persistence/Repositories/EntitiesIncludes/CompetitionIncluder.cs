using System.Data.Entity;
using System.Linq;
using TetBet.Infrastructure.Entities;

namespace TetBet.Infrastructure.Persistence.Repositories.EntitiesIncludes
{
    public class CompetitionIncluder : EntitiesIncluder<Competition>
    {
        protected override IQueryable<Competition> SetIncludes(IQueryable<Competition> query)
            => query
                .Include(competition => competition.Country)
                .Include(competition => competition.Sport)
                .Include(competition => competition.SportEntities);
    }
}