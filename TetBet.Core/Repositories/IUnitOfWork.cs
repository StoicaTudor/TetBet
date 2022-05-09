namespace TetBet.Core.Repositories
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; set; }
        public ISportEventRepository SportEventRepository { get; set; }
        public IBettingTicketRepository BettingTicketRepository { get; set; }
        public ITransactionRepository TransactionRepository { get; set; }
        void Commit();
    }
}