
using TetBet.Data.Entities;

namespace TetBet.Infrastructure.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>
    {
        public TransactionRepository(ApplicationContext context) : base(context)
        {
        }
    }
}