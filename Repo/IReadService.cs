using System.Data;

namespace MarketsAPI.Repo
{
    public interface IReadService
    {
        DataSet? ReadStates();
        DataSet? ReadDistricts(int StateId);
        DataSet? ReadMandals(int districtID);
        DataSet? ReadVillages(int mandalID);
        DataSet? ReadGenders();
        DataSet? ReadSalutations();
        DataSet? ReadCastes();
        DataSet? ReadDistrictMarkets(int districtID);
        DataSet? ReadMills(int MarketId);
        DataSet? CheckFarmerApproval(string barCode);
        DataSet? GetFarmerDetailsWithMobileNumber(string mobileNumber);
        DataSet? GetFarmerDetailsByBarCode(string barCode);
        DataSet? GetFarmerDetailsByID(int farmerId);
        DataSet? ReadFarmerType();
        DataSet? ReadAvailableSlots(int centerId, string monthId, int DayId);
        DataSet? ReadSlotBookingInfo(int farmerId);
        DataSet? ReadFarmerUploadedProofs(int farmerId);
        DataSet? ReadSlotInfoFromMobileNumber(string MobileNumber);
        DataSet? GetOpenSlotCount(int farmerId);
        DataSet? GetBarcodesByMobileNumber(string mobileNumber);
        DataSet? GetUinqueNames(int satateId);
    }
}
