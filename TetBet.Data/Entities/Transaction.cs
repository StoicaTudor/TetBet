using System;

namespace TetBet.Data.Entities
{
    public class Transaction : EntityBase
    {
        public float Sum { get; set; }
        public DateTime Date { get; set; }

        public AccountDetails AccountDetails { get; set; }
    }
}