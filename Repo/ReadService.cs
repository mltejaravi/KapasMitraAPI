using MarketsAPI.DB;
using MarketsAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace MarketsAPI.Repo
{
    public class ReadService : IReadService
    {
        private IConfiguration? configuration;
        private string? ConnectionString = string.Empty;
        private ConnectToDb? connectToDb = null;
        public ReadService(IConfiguration _configuration)
        {
            configuration = _configuration;
            ConnectionString = configuration?["ConnectionStrings:Emarkets"] ?? "";

            if (!string.IsNullOrEmpty(ConnectionString))
            {
                connectToDb = new ConnectToDb(ConnectionString);
            }
            else
            {
                throw new ArgumentNullException(nameof(ConnectionString), "Connection string cannot be null or empty.");
            }
        }

        public DataSet? ReadStates()
        {
            DataSet? dataSet = new DataSet();

            dataSet = connectToDb!?.ReadFromSql(Enums.USP_GET_STATES.ToString(), true, "States");

            return dataSet;
        }
        public DataSet? ReadDistricts(int StateId)
        {
            DataSet? dataSet = new DataSet();

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@StateID", StateId)
            };

            dataSet = connectToDb!?.ReadFromSql(Enums.USP_GET_Districts.ToString(), true, "Districts", parameters);

            return dataSet;
        }
        public DataSet? ReadMandals(int districtID)
        {
            DataSet? dataSet = new DataSet();

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@DistrictID", districtID)
            };

            dataSet = connectToDb!?.ReadFromSql(Enums.USP_GET_MANDALS.ToString(), true, "Mandals", parameters);

            return dataSet;
        }
        public DataSet? ReadVillages(int MandalId)
        {
            DataSet? dataSet = new DataSet();

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@mandalID", MandalId)
            };

            dataSet = connectToDb!?.ReadFromSql(Enums.USP_GET_VILLAGES.ToString(), true, "Villages", parameters);

            return dataSet;
        }
        public DataSet? ReadGenders()
        {
            DataSet? dataSet = new DataSet();

            dataSet = connectToDb!?.ReadFromSql(Enums.USP_GET_GENDERS.ToString(), true, "Genders");

            return dataSet;
        }

        public DataSet? ReadSalutations()
        {
            DataSet? dataSet = new DataSet();
            dataSet = connectToDb!?.ReadFromSql(Enums.USP_GET_SALUTATIONS.ToString(), true, "Salutations");
            return dataSet;
        }
        public DataSet? ReadCastes()
        {
            DataSet? dataSet = new DataSet();

            dataSet = connectToDb!?.ReadFromSql(Enums.USP_GET_CASTES.ToString(), true, "Castes");

            return dataSet;
        }

        public DataSet? ReadFarmerType()
        {
            DataSet? dataSet = new DataSet();

            dataSet = connectToDb!?.ReadFromSql(Enums.USP_GET_FarmerTypes.ToString(), true, "Castes");

            return dataSet;
        }
        public DataSet? ReadDistrictMarkets(int districtID)
        {
            DataSet? dataSet = new DataSet();

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@districtID", districtID)
            };

            dataSet = connectToDb!?.ReadFromSql(Enums.USP_GET_DISTMARKETS.ToString(), true, "DistrictMarkets", parameters);

            return dataSet;
        }
        public DataSet? ReadMills(int MarketId)
        {
            DataSet? dataSet = new DataSet();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@MarketID", MarketId)
            };
            dataSet = connectToDb!?.ReadFromSql(Enums.USP_GET_CCIMILLSBYCENTER.ToString(), true, "Mills", parameters);
            return dataSet;
        }
        public DataSet? ReadAvailableSlots(int centerId, string monthId, int DayId)
        {
            DataSet? dataSet = new DataSet();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@CENTERID", centerId),
                new SqlParameter("@MONTHID", monthId),
                new SqlParameter("@DAYID", DayId)
            };
            dataSet = connectToDb!?.ReadFromSql(Enums.FS_SP_POPAVAILABLESLOTS.ToString(), true, "AvailableSlots", parameters);
            return dataSet;
        }
        public DataSet? ReadSlotBookingInfo(int farmerId)
        {
            DataSet? dataSet = new DataSet();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FARMERID", farmerId)
            };
            dataSet = connectToDb!?.ReadFromSql(Enums.FS_SP_POP_SLOTBOOKINGINFO.ToString(), true, "SlotBookingInfo", parameters);
            return dataSet;
        }
        public DataSet? ReadFarmerUploadedProofs(int farmerId)
        {
            DataSet? dataSet = new DataSet();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FarmerID", farmerId)
            };
            dataSet = connectToDb!?.ReadFromSql(Enums.USP_POPFARMERUPLOADEDPROOFS.ToString(), true, "FarmerUploadedProofs", parameters);
            return dataSet;
        }
        public DataSet? ReadSlotInfoFromMobileNumber(string MobileNumber)
        {
            DataSet? dataSet = new DataSet();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@MOBILENO", MobileNumber)
            };
            dataSet = connectToDb!?.ReadFromSql(Enums.FS_SP_POP_SLOTBOOKINGINFOBYMOBILENO.ToString(), true, "SlotInfo", parameters);
            return dataSet;
        }
        public DataSet? CheckFarmerApproval(string barCode)
        {
            DataSet? dataSet = new DataSet();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@BarCode", barCode)
            };
            dataSet = connectToDb!?.ReadFromSql(Enums.USP_Check_FarmerRegistrationApproval.ToString(), true, "FarmerApproval", parameters);
            return dataSet;
        }

        public DataSet? GetFarmerDetailsWithMobileNumber(string mobileNumber)
        {
            DataSet? dataSet = new DataSet();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@MobileNo", mobileNumber)
            };
            dataSet = connectToDb!?.ReadFromSql(Enums.USP_Get_FarmerDetails.ToString(), true, "FarmerDetails", parameters);
            return dataSet;
        }

        public DataSet? GetFarmerDetailsByBarCode(string barCode)
        {
            DataSet? dataSet = new DataSet();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Barcode", barCode)
            };
            dataSet = connectToDb!?.ReadFromSql(Enums.USP_Get_FarmerDetails_BY_BarCode.ToString(), true, "FarmerDetailsByBarCode", parameters);
            return dataSet;
        }

        public DataSet? GetFarmerDetailsByID(int farmerId)
        {
            DataSet? dataSet = new DataSet();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FarmerID", farmerId)
            };
            dataSet = connectToDb!?.ReadFromSql(Enums.USP_Get_FarmerDetailsByID.ToString(), true, "FarmerDetailsByID", parameters);
            return dataSet;
        }

        public DataSet? GetOpenSlotCount(int farmerId)
        {
            DataSet? dataSet = new DataSet();

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FARMERID", farmerId)
            };
            dataSet = connectToDb!?.ReadFromSql(Enums.USP_OPENSLOTSOFFARMER.ToString(), true, "OpenSlotCount", parameters);
            return dataSet;
        }

        public DataSet? GetBarcodesByMobileNumber(string mobileNumber)
        {
            DataSet? dataSet = new DataSet();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@MobileNo", mobileNumber)
            };
            dataSet = connectToDb!?.ReadFromSql(Enums.USP_GET_BARCODES_BY_MOBILE_NUMBER.ToString(), true, "BarcodesByMobileNumber", parameters);
            return dataSet;
        }

        public DataSet? GetUinqueNames(int satateId)
        {
            DataSet? dataSet = new DataSet();
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@StateID", satateId)
            };
            dataSet = connectToDb!?.ReadFromSql(Enums.S_POP_STATENOMENCLATURE.ToString(), true, "UniqueNames", parameters);
            return dataSet;
        }

        public DataSet? GetFarmerProofsByBarcode(string barCode)
        {
            DataSet? dataSet = new DataSet();
            var parameters = new SqlParameter[]{
                new SqlParameter("@Barcode", barCode)
            };

            dataSet = connectToDb!?.ReadFromSql(Enums.USP_Get_FarmerProofs_BY_BarCode.ToString(), true, "Proofs", parameters);
            return dataSet;
        }

        public DataSet? GetLandDetailsByBarcode(string barCode)
        {
            DataSet? dataSet = new DataSet();
            var parameters = new SqlParameter[]{
                new SqlParameter("@Barcode", barCode)
            };

            dataSet = connectToDb!?.ReadFromSql(Enums.USP_GET_LAND_Details.ToString(), true, "LandDetails", parameters);
            return dataSet;
        }

        public DataSet? GetAnnouncements()
        {
            DataSet? dataSet = new DataSet();
            dataSet = connectToDb?.ReadFromSql(Enums.USP_GET_Announcements.ToString(), true, "Announcements", null);
            return dataSet;
        }

        public DataSet? GetHelpLineNumbers()
        {
            DataSet? dataSet = new DataSet();
            dataSet = connectToDb?.ReadFromSql(Enums.USP_GET_HELPLineNumbers.ToString(), true, "HelpLineNumbers", null);
            return dataSet;
        }
    }
}