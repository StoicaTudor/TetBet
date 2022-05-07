using System;

namespace TetBet.Core.Dtos
{
    public class TransactionGetDto
    {
        public long Id { get; set; }
        public float Sum { get; set; }
        public DateTime Date { get; set; }
    }
}