using MarketsAPI.DB;
using MarketsAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MarketsAPI.Repo
{
    public class Register : IRegister
    {
        private IConfiguration? configuration;
        private string? ConnectionString = string.Empty;
        private ConnectToDb? connectToDb = null;
        public Register(IConfiguration? _configuration)
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
        public DataTable RegisterFarmer(Farmer farmer)
        {
            if (farmer == null)
            {
                throw new ArgumentNullException(nameof(farmer), "Farmer cannot be null.");
            }

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Flag", SqlDbType.Int) { Value = farmer.Flag },
                new SqlParameter("@Id", SqlDbType.Decimal) { Precision = 10, Scale = 0, Value = farmer.Id },
                new SqlParameter("@Barcode", SqlDbType.VarChar, 50) { Value = (object?)farmer.Barcode ?? DBNull.Value },
                new SqlParameter("@farmerType", SqlDbType.Decimal) { Precision = 10, Scale = 0, Value = farmer.FarmerType },
                new SqlParameter("@SalutationID", SqlDbType.Int) { Value = farmer.SalutationID },
                new SqlParameter("@GenderID", SqlDbType.Int) { Value = farmer.GenderID },
                new SqlParameter("@FarmerFullname", SqlDbType.VarChar, 100) { Value = (object?)farmer.FarmerFullname ?? DBNull.Value },
                new SqlParameter("@Fname", SqlDbType.VarChar, 100) { Value = (object?)farmer.Fname ?? DBNull.Value },
                new SqlParameter("@PassBookNo", SqlDbType.VarChar, 50) { Value = (object?)farmer.PassBookNo ?? DBNull.Value },
                new SqlParameter("@Fk_District", SqlDbType.Decimal) { Precision = 10, Scale = 0, Value = farmer.Fk_District },
                new SqlParameter("@Fk_Mandal", SqlDbType.Decimal) { Precision = 10, Scale = 0, Value = farmer.Fk_Mandal },
                new SqlParameter("@Fk_Village", SqlDbType.Decimal) { Precision = 10, Scale = 0, Value = farmer.Fk_Village },
                new SqlParameter("@AadharNo", SqlDbType.VarChar, 100) { Value = (object?)farmer.AadharNo ?? DBNull.Value },
                new SqlParameter("@MobileNo", SqlDbType.VarChar, 50) { Value = (object?)farmer.MobileNo ?? DBNull.Value },
                new SqlParameter("@TotalLand", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = farmer.TotalLand },
                new SqlParameter("@NoOfAcr", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = farmer.NoOfAcr },
                new SqlParameter("@MARKETid", SqlDbType.Decimal) { Precision = 10, Scale = 0, Value = farmer.MarketId },
                new SqlParameter("@category", SqlDbType.Int) { Value = farmer.Category },
                new SqlParameter("@Address", SqlDbType.VarChar, 200) { Value = (object?)farmer.Address ?? DBNull.Value },
                new SqlParameter("@DOB", SqlDbType.DateTime) { Value = (object?)farmer.DOB ?? DBNull.Value },
                new SqlParameter("@Uniq_1", SqlDbType.VarChar) { Value = farmer.Uniq_1 },
                new SqlParameter("@Uniq_2", SqlDbType.VarChar) { Value = farmer.Uniq_2 },
                new SqlParameter("@Uniq_3", SqlDbType.VarChar) { Value = farmer.Uniq_3 },
                new SqlParameter("@Uniq_4", SqlDbType.VarChar) { Value = farmer.Uniq_4 },
                new SqlParameter("@tc",SqlDbType.Decimal){ Precision = 10, Scale = 2, Value = farmer.tc },
                new SqlParameter("@hd",SqlDbType.Decimal){ Precision = 10, Scale = 2, Value = farmer.hd },
                new SqlParameter("@dc",SqlDbType.Decimal){ Precision = 10, Scale = 2, Value = farmer.dc },
                new SqlParameter("@cs",SqlDbType.Decimal){ Precision = 10, Scale = 2, Value = farmer.cs },
                new SqlParameter("@MeasureType",SqlDbType.Int){Value=farmer.MeasureType},
                new SqlParameter("@UniqIdsTotalLand",SqlDbType.VarChar){Value= farmer.UniqIdsTotalLand}
            };

            DataTable? rows = connectToDb?.InsertToSql(Enums.USP_MA_Farmer_Registration.ToString(), true, parameters);

            if (rows == null || rows.Rows.Count <= 0)
            {
                throw new Exception("Failed to register farmer. No rows affected.");
            }

            return rows;
        }
        public int? RegisterFarmerDocuments(FarmerDocuments farmerDocuments)
        {
            if (farmerDocuments == null)
            {
                throw new ArgumentNullException(nameof(farmerDocuments), "Farmer documents cannot be null.");
            }
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FarmerID", SqlDbType.Decimal) { Precision = 10, Scale = 0, Value = farmerDocuments.FarmerID },
                new SqlParameter("@TypeID", SqlDbType.Int) { Value = farmerDocuments.TypeID },
                new SqlParameter("@Proof", SqlDbType.Image) { Value = (object?)farmerDocuments.Proof ?? DBNull.Value },
                new SqlParameter("@Type", SqlDbType.VarChar) { Value = (object?)farmerDocuments.Type ?? DBNull.Value }

            };
            int? rows = connectToDb?.InsertSql(Enums.USP_UPDATEFARMERPROOFS.ToString(), true, parameters);
            if (rows == null)
            {
                throw new Exception("Failed to register farmer documents. No rows affected.");
            }
            return rows;
        }

        public int? RegisterSlotBooking(SlotBooking slotBooking)
        {
            if (slotBooking == null)
            {
                throw new ArgumentNullException(nameof(slotBooking), "Slot booking cannot be null.");
            }
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FARMERID", SqlDbType.Int) { Precision = 10, Scale = 0, Value = slotBooking.FarmerId },
                new SqlParameter("@DAYSLOTID", SqlDbType.Int) { Precision = 10, Scale = 0, Value = slotBooking.DaySlotId },
                new SqlParameter("@CENTERID", SqlDbType.Int) { Value = slotBooking.CenterId },
                new SqlParameter("@TRANSACTIONID", SqlDbType.VarChar) { Value = slotBooking.TransactionId },
                new SqlParameter("@APPROXWGT", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = (object?)slotBooking.ApproxWgt ?? DBNull.Value },
                new SqlParameter("@REMARKS", SqlDbType.VarChar) { Value = (object?)slotBooking.Remarks ?? DBNull.Value },
                new SqlParameter("@USERID", SqlDbType.Int) { Value = slotBooking.UserId }
            };
            int? rows = connectToDb?.InsertSql(Enums.FS_SP_SAVESLOTBOOKINGINFO.ToString(), true, parameters);
            if (rows == null)
            {
                throw new Exception("Failed to register slot booking. No rows affected.");
            }
            return rows;
        }

        public int? CancelSlotBooking(CancelSlot cancelSlot)
        {
            if (cancelSlot == null)
            {
                throw new ArgumentNullException(nameof(cancelSlot), "Cancel slot cannot be null.");
            }
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@BOOKINGNO", SqlDbType.VarChar) {  Value = cancelSlot.BOOKINGNO },
                new SqlParameter("@CANCELREMARKS", SqlDbType.VarChar) { Value = (object?)cancelSlot.CANCELREMARKS ?? DBNull.Value },
                new SqlParameter("@CANCELUSER", SqlDbType.Int) { Value = cancelSlot.CANCELUSER }

            };
            int? rows = connectToDb?.InsertSql(Enums.USP_CANCELSLOTBOOKING.ToString(), true, parameters);
            if (rows == null)
            {
                throw new Exception("Failed to cancel slot booking. No rows affected.");
            }
            return rows;
        }

        public int? AddLand(int FarmerId, decimal TotalLand, decimal CottonLand, int MARKETID, int VILLAGEID, string UNIQUEID)
        {
            if (FarmerId <= 0)
            {
                throw new ArgumentException("FarmerId must be greater than zero.", nameof(FarmerId));
            }
            if (TotalLand < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(TotalLand), "TotalLand cannot be negative.");
            }
            if (CottonLand < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(CottonLand), "CottonLand cannot be negative.");
            }
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FarmerId", SqlDbType.Int) { Precision = 10, Scale = 0, Value = FarmerId },
                new SqlParameter("@MARKETID", SqlDbType.Int) { Precision = 10, Scale = 0, Value = MARKETID },
                new SqlParameter("@VILLAGEID", SqlDbType.Int) { Precision = 10, Scale = 0, Value = VILLAGEID },
                new SqlParameter("@UNIQUEID", SqlDbType.VarChar) { Value = UNIQUEID},
                new SqlParameter("@TotalLand", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = TotalLand },
                new SqlParameter("@CottonLand", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = CottonLand }
            };
            int? rows = connectToDb?.InsertSql(Enums.USP_ADD_LAND.ToString(), true, parameters);
            if (rows == null)
            {
                throw new Exception("Failed to add land. No rows affected.");
            }
            return rows;
        }
        public int? AddLandExtended(Land land)
        {
            if (land.FarmerId <= 0)
            {
                throw new ArgumentException("FarmerId must be greater than zero.", nameof(land.FarmerId));
            }
            if (land.TotalLand < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(land.TotalLand), "TotalLand cannot be negative.");
            }
            if (land.CottonLand < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(land.CottonLand), "CottonLand cannot be negative.");
            }
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@FarmerId", SqlDbType.Int) { Precision = 10, Scale = 0, Value = land.FarmerId },
                new SqlParameter("@MARKETID", SqlDbType.Int) { Precision = 10, Scale = 0, Value = land.MARKETID },
                new SqlParameter("@VILLAGEID", SqlDbType.Int) { Precision = 10, Scale = 0, Value = land.VILLAGEID },
                new SqlParameter("@UNIQUEID", SqlDbType.VarChar) { Value = land.UNIQUEID},
                new SqlParameter("@TotalLand", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = land.TotalLand },
                new SqlParameter("@CottonLand", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = land.CottonLand },
                new SqlParameter("@Uniq_1", SqlDbType.VarChar) { Value = land.Uniq_1 },
                new SqlParameter("@Uniq_2", SqlDbType.VarChar) { Value = land.Uniq_2 },
                new SqlParameter("@Uniq_3", SqlDbType.VarChar) { Value = land.Uniq_3 },
                new SqlParameter("@Uniq_4", SqlDbType.VarChar) { Value = land.Uniq_4 },
                new SqlParameter("@tc",SqlDbType.Decimal){ Precision = 10, Scale = 2, Value = land.tc },
                new SqlParameter("@hd",SqlDbType.Decimal){ Precision = 10, Scale = 2, Value = land.hd },
                new SqlParameter("@dc",SqlDbType.Decimal){ Precision = 10, Scale = 2, Value = land.dc },
                new SqlParameter("@cs",SqlDbType.Decimal){ Precision = 10, Scale = 2, Value = land.cs },
                new SqlParameter("@MeasureType",SqlDbType.Int){Value=land.MeasureType}
            };
            int? rows = connectToDb?.InsertSql(Enums.USP_ADD_LAND.ToString(), true, parameters);
            if (rows == null)
            {
                throw new Exception("Failed to add land. No rows affected.");
            }
            return rows;
        }

        public int? CreateLog(ActivityLog log)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("AppID", SqlDbType.Int) { Value = log.AppId },
                new SqlParameter("AppName", SqlDbType.VarChar, 20) { Value = log.AppName },
                new SqlParameter("LoginId", SqlDbType.VarChar, 50) { Value =  log.LoginId },
                new SqlParameter("ErrorShortDesc", SqlDbType.VarChar, -1) { Value =  log.ErrorShortDesc },
                new SqlParameter("ErrorDesc", SqlDbType.VarChar, -1) { Value =  log.ErrorDesc },
                new SqlParameter("LogInfo", SqlDbType.VarChar, -1) { Value = log.LogInfo }
            };

            int? rows = connectToDb?.InsertSql(Enums.USP_SaveLog.ToString(), true, parameters);
            if (rows == null)
            {
                throw new Exception("Failed to create log. No rows affected.");
            }
            return rows;
        }

        public int? CreateTransactionLog(TransactionLog transactionLog)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@FarmerId", SqlDbType.Int){ Value = transactionLog.FarmerId },
                new SqlParameter("@Status", SqlDbType.Int){ Value = transactionLog.Status},
                new SqlParameter("@ErrorLog", SqlDbType.VarChar) { Value = transactionLog.ErrorLog }
            };

            int? rows = connectToDb!?.InsertSql(Enums.USP_Create_Log.ToString(), true, parameters);

            if (rows == null)
            {
                throw new Exception("Failed to create transaction log. No rows affected.");
            }
            return rows;
        }

        public int? RollbackFarmerOnFailOver(int FarmerId)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@FarmerId", SqlDbType.Int){ Value = FarmerId }
            };

            int? rows = connectToDb!?.InsertSql(Enums.USP_Rollback_FarmerDetails_OnFailOver.ToString(), true, parameters);

            if (rows == null)
            {
                throw new Exception("Failed to create failover. No rows affected.");
            }
            return rows;
        }
    }
}
