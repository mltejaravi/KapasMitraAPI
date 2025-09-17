using System;

namespace MarketsAPI.Models
{
    public class TransactionLog
    {
        public int FarmerId { get; set; }
        public int Status { get; set; }
        public string? ErrorLog{ get; set; }
    }
}