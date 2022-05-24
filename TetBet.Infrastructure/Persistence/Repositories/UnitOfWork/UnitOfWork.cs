using TetBet.Infrastructure.Entities;

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

        public UnitOfWork(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

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

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}