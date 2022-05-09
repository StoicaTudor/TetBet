using System.ComponentModel.DataAnnotations;

namespace TetBet.Data.Entities
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}