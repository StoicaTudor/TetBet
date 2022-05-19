using Microsoft.EntityFrameworkCore;
using TetBet.Infrastructure.Entities;
using AccountDetails = TetBet.Infrastructure.Entities.AccountDetails;
using Bet = TetBet.Infrastructure.Entities.Bet;
using BettingTicket = TetBet.Infrastructure.Entities.BettingTicket;
using Competition = TetBet.Infrastructure.Entities.Competition;
using Country = TetBet.Infrastructure.Entities.Country;
using GenericBet = TetBet.Infrastructure.Entities.GenericBet;
using Sport = TetBet.Infrastructure.Entities.Sport;
using SportEntity = TetBet.Infrastructure.Entities.SportEntity;
using SportEvent = TetBet.Infrastructure.Entities.SportEvent;
using SportEventBet = TetBet.Infrastructure.Entities.SportEventBet;
using SportRelatedHuman = TetBet.Infrastructure.Entities.SportRelatedHuman;
using Transaction = TetBet.Infrastructure.Entities.Transaction;
using User = TetBet.Infrastructure.Entities.User;
using UserBet = TetBet.Infrastructure.Entities.UserBet;

namespace TetBet.Infrastructure.Persistence
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        public DbSet<AccountDetails> AccountDetails { get; set; }
        public DbSet<Bet> Bet { get; set; }
        public DbSet<BettingTicket> BettingTicket { get; set; }
        public DbSet<Competition> Competition { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<SportEntity> FootballEvent { get; set; }
        public DbSet<GenericBet> GenericBet { get; set; }
        public DbSet<Sport> Sport { get; set; }
        public DbSet<SportEvent> SportEvent { get; set; }
        public DbSet<SportEventBet> SportEventBet { get; set; }
        public DbSet<SportRelatedHuman> SportRelatedHuman { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserBet> UserBet { get; set; }

        public DbSet<RapidApiConfigData> RapidApiConfigData { get; set; }
        public DbSet<RapidApiKey> RapidApiKey { get; set; }
    }
}