using System.Threading.Tasks;
using Quartz;

namespace TetBet.Server.Services.Routine
{
    public class RoutineJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}