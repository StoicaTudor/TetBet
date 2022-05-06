
namespace TetBet.Core.Entities
{
    public abstract class GenericBet
    {
        public long Id { get; set; }
        public Sport Sport { get; set; }
        public string Name { get; set; }
    }
}