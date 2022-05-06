using System;

namespace TetBet.Core.Entities
{
    public class Transaction
    {
        public long Id { get; set; }

        public float Sum { get; set; }
        public DateTime Date { get; set; }

        public AccountDetails AccountDetails { get; set; }
    }
}