using System;

namespace TetBet.Infrastructure.Entities
{
    public class Transaction : Infrastructure.Entities.EntityBase
    {
        public float Sum { get; set; }
        public DateTime Date { get; set; }

        public long AccountDetailsId { get; set; }
        public AccountDetails AccountDetails { get; set; }
    }
}