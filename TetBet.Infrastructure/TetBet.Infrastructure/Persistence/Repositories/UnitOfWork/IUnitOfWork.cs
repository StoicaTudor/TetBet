using TetBet.Infrastructure.Entities;

namespace TetBet.Infrastructure.Persistence.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<User> User { get; }
        public IRepository<SportEvent> SportEvent { get; }
        public IRepository<BettingTicket> BettingTicket { get; }
        public IRepository<Transaction> Transaction { get; }
        public IRepository<RapidApiKey> RapidApiKey { get; }
        public IRepository<RapidApiConfigData> RapidApiConfigData { get; }
        public IRepository<Competition> Competition { get; }
        public IRepository<SportEntity> SportEntity { get; }
        void Commit();
    }
}