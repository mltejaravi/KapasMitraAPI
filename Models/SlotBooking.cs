namespace MarketsAPI.Models
{
    public class SlotBooking
    {
        public decimal FarmerId { get; set; }
        public decimal DaySlotId { get; set; }
        public decimal CenterId { get; set; }
        public string TransactionId { get; set; } = string.Empty;
        public decimal ApproxWgt { get; set; } = 0.00M;
        public string Remarks { get; set; } = string.Empty;
        public int UserId { get; set; } = 0;
    }
    public class CancelSlot
    {
        public string BOOKINGNO { get; set; } = string.Empty;
        public string CANCELREMARKS { get; set; } = string.Empty;
        public int CANCELUSER { get; set; } = 0;
    }
}
