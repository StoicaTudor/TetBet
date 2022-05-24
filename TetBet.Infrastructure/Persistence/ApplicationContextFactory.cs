using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Unity;

namespace TetBet.Infrastructure.Persistence
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            IocConfig.RegisterComponents();
            var container = IocConfig.GetConfiguredContainer();

            // set up options
            DbContextOptionsBuilder optionsBuilder = new();
            optionsBuilder.UseMySQL(
                "server = localhost; port = 3306; user = Citadin2; password = Aaladin2000-; database = TetBet");

            return container.Resolve<ApplicationContext>();
        }
    }
}