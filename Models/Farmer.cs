namespace MarketsAPI.Models
{
    public class Farmer
    {
        public int Flag { get; set; }
        public long Id { get; set; }
        public string? Barcode { get; set; }
        public long FarmerType { get; set; }
        public int SalutationID { get; set; }
        public int GenderID { get; set; }
        public string? FarmerFullname { get; set; }
        public string? Fname { get; set; }
        public string? PassBookNo { get; set; }
        public long Fk_District { get; set; }
        public long Fk_Mandal { get; set; }
        public long Fk_Village { get; set; }
        public string? AadharNo { get; set; }
        public string? MobileNo { get; set; }
        public decimal TotalLand { get; set; }
        public decimal NoOfAcr { get; set; }
        public long MarketId { get; set; }
        public int Category { get; set; }
        public string? Address { get; set; }
        public string? DOB { get; set; }
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
    public class FarmerDocuments
    {
        public decimal FarmerID { get; set; }
        public int TypeID { get; set; }
        public byte[]? Proof { get; set; }
        public string? Type { get; set; }
    }
}
