
using TetBet.Data.Entities;
using Transaction = TetBet.Infrastructure.Entities.Transaction;

namespace TetBet.Infrastructure.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>
    {
        public TransactionRepository(ApplicationContext context) : base(context)
        {
        }
    }
}