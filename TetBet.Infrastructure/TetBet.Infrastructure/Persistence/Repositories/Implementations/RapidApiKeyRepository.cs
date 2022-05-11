using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.Interfaces;

namespace TetBet.Infrastructure.Persistence.Repositories.Implementations
{
    public class RapidApiKeyRepository : BaseRepository<RapidApiKey>
    {
        public RapidApiKeyRepository(ApplicationContext context) : base(context)
        {
        }
    }
}