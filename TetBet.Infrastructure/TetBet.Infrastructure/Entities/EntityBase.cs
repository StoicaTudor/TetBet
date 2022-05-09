using System.ComponentModel.DataAnnotations;

namespace TetBet.Infrastructure.Entities
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}