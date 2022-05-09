using Microsoft.EntityFrameworkCore;
using TetBet.Data.Entities;

namespace TetBet.Infrastructure.Persistence
{
    public class ApplicationContext : DbContext
    {
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
    }
}