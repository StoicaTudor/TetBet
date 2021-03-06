using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.EntitiesIncludes;

namespace TetBet.Infrastructure.Persistence.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _dbContext;

        private IRepository<User> _userRepository;
        private IRepository<SportEvent> _sportEventRepository;
        private IRepository<BettingTicket> _bettingTicketRepository;
        private IRepository<Transaction> _transactionRepository;
        private IRepository<RapidApiKey> _rapidApiKeyRepository;
        private IRepository<RapidApiConfigData> _rapidApiConfigData;
        private IRepository<Competition> _competitionRepository;
        private IRepository<SportEntity> _sportEntity;
        private IRepository<AccountDetails> _accountDetails;
        private IRepository<Country> _country;
        private IRepository<Sport> _sport;
        private IRepository<UserBet> _userBet;
        private IRepository<GenericBet> _genericBet;
        private IRepository<Bet> _bet;

        private EntitiesIncluder<User> _userIncluder;
        private EntitiesIncluder<Competition> _competitionIncluder;

        public UnitOfWork(ApplicationContext dbContext)
            => _dbContext = dbContext;

        public IRepository<User> User =>
            _userRepository ??= new BaseRepository<User>(_dbContext);

        public IRepository<SportEvent> SportEvent =>
            _sportEventRepository ??= new BaseRepository<SportEvent>(_dbContext);

        public IRepository<BettingTicket> BettingTicket =>
            _bettingTicketRepository ??= new BaseRepository<BettingTicket>(_dbContext);

        public IRepository<Transaction> Transaction =>
            _transactionRepository ??= new BaseRepository<Transaction>(_dbContext);

        public IRepository<RapidApiKey> RapidApiKey =>
            _rapidApiKeyRepository ??= new BaseRepository<RapidApiKey>(_dbContext);

        public IRepository<RapidApiConfigData> RapidApiConfigData =>
            _rapidApiConfigData ??= new BaseRepository<RapidApiConfigData>(_dbContext);

        public IRepository<Competition> Competition =>
            _competitionRepository ??= new BaseRepository<Competition>(_dbContext);

        public IRepository<SportEntity> SportEntity =>
            _sportEntity ??= new BaseRepository<SportEntity>(_dbContext);

        public IRepository<AccountDetails> AccountDetails =>
            _accountDetails ??= new BaseRepository<AccountDetails>(_dbContext);

        public IRepository<Country> Country =>
            _country ??= new BaseRepository<Country>(_dbContext);

        public IRepository<Sport> Sport =>
            _sport ??= new BaseRepository<Sport>(_dbContext);

        public IRepository<UserBet> UserBet =>
            _userBet ??= new BaseRepository<UserBet>(_dbContext);

        public IRepository<GenericBet> GenericBet =>
            _genericBet ??= new BaseRepository<GenericBet>(_dbContext);

        public IRepository<Bet> Bet =>
            _bet ??= new BaseRepository<Bet>(_dbContext);

        public EntitiesIncluder<User> UserIncluder =>
            _userIncluder ??= new UserIncludes();

        public EntitiesIncluder<Competition> CompetitionIncluder =>
            _competitionIncluder ??= new CompetitionIncluder();

        public void Commit()
            => _dbContext.SaveChanges();
    }
}