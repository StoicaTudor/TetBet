using TetBet.Infrastructure.Persistence.Repositories.Interfaces;
using Transaction = TetBet.Infrastructure.Entities.Transaction;

namespace TetBet.Infrastructure.Persistence.Repositories.Implementations
{
    public class TransactionRepository : BaseRepository<Transaction>
    {
        public TransactionRepository(ApplicationContext context) : base(context)
        {
        }
    }
}