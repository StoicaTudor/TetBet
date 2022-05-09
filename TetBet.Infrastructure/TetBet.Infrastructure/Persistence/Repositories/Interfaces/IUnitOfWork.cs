using TetBet.Infrastructure.Entities;

namespace TetBet.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public BaseRepository<User> UserRepository { get; set; }
        public BaseRepository<SportEvent> SportEventRepository { get; set; }
        public BaseRepository<BettingTicket> BettingTicketRepository { get; set; }
        public BaseRepository<Transaction> TransactionRepository { get; set; }
        void Commit();
    }
}