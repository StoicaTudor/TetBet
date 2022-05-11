using System;

namespace TetBet.Infrastructure.Entities
{
    public class RapidApiKey : EntityBase
    {
        public string Key { get; set; }
        public string ApiDescription { get; set; }
        public int RemainingCalls { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}