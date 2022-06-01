namespace TetBet.Infrastructure.Persistence.Repositories
{
    public class IncludeTool
    {
        public IncludeTool Include(string className)
        {
            return this;
        }
        
        public IncludeTool ThenInclude(string className)
        {
            return this;
        }
    }
}