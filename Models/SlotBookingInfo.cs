namespace MarketsAPI.Models
{
    public class SlotBookingInfo
    {
        public int DayID { get; set; }
        public int MonthID {get;set;}
        public int BookingNo {get;set;}
        public string? GinningMillName {get;set;}
        public string? MarketName {get;set;}
        public string? CenterSlotTimeName{get;set;}
    }
}
