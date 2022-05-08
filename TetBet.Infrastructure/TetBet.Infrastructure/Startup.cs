using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TetBet.Infrastructure.Persistence;

namespace TetBet.Infrastructure
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // configure DBContext with SQL DBs
            services.AddDbContext<ApplicationContext>(options =>
                options.UseMySQL(
                    "server = localhost; port = 3306; user = Citadin2; password = Aaladin2000-; database = TetBet"));
        }
    }
}