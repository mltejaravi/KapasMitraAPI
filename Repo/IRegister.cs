using MarketsAPI.Models;
using System.Data;

namespace MarketsAPI.Repo
{
    public interface IRegister
    {
        DataTable RegisterFarmer(Farmer farmer);
        int? RegisterFarmerDocuments(FarmerDocuments farmerDocuments);
        int? RegisterSlotBooking(SlotBooking slotBooking);
        int? AddLand(int FarmerId, decimal TotalLand, decimal CottonLand, int MARKETID, int VILLAGEID, string UNIQUEID);
        int? AddLandExtended(Land land);
        int? CancelSlotBooking(CancelSlot cancelSlot);
        int? CreateLog(ActivityLog log);
    }
}
