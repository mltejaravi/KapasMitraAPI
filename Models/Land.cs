namespace MarketsAPI.Models
{
    public class Land
    {
        public int FarmerId { get; set; }
        public decimal TotalLand { get; set; }
        public decimal CottonLand { get; set; }
        public int MARKETID { get; set; }
        public int VILLAGEID { get; set; }
        public string? UNIQUEID { get; set; }
        public string? Uniq_1 { get; set; }
        public string? Uniq_2 { get; set; }
        public string? Uniq_3 { get; set; }
        public string? Uniq_4 { get; set; }
        public decimal tc { get; set; }
        public decimal hd { get; set; }
        public decimal dc { get; set; }
        public decimal cs { get; set; }
        public int MeasureType{ get; set; }
    }
}
