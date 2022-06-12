using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.EntitiesIncludes;

namespace TetBet.Infrastructure.Persistence.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<User> User { get; }
        public IRepository<AccountDetails> AccountDetails { get; }
        public IRepository<SportEvent> SportEvent { get; }
        public IRepository<BettingTicket> BettingTicket { get; }
        public IRepository<Transaction> Transaction { get; }
        public IRepository<RapidApiKey> RapidApiKey { get; }
        public IRepository<RapidApiConfigData> RapidApiConfigData { get; }
        public IRepository<Competition> Competition { get; }
        public IRepository<SportEntity> SportEntity { get; }
        public IRepository<Country> Country { get; }
        public IRepository<Sport> Sport { get; }
        public IRepository<UserBet> UserBet { get; }
        public IRepository<GenericBet> GenericBet { get; }
        public IRepository<Bet> Bet { get; }

        public EntitiesIncluder<User> UserIncluder { get; }
        public EntitiesIncluder<Competition> CompetitionIncluder { get; }
        void Commit();
    }
}