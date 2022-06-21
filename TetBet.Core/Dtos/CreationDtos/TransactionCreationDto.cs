using System;

namespace TetBet.Core.Dtos.CreationDtos
{
    public class TransactionCreationDto
    {
        public float Sum { get; set; }
        public DateTime Date { get; set; }
        public string Currency { get; set; }
    }
}