using System;

namespace TetBet.Infrastructure.Entities
{
    public class Transaction : Infrastructure.Entities.EntityBase
    {
        public float Sum { get; set; }
        public DateTime Date { get; set; }

        public Infrastructure.Entities.AccountDetails AccountDetails { get; set; }
    }
}