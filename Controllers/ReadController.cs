using MarketsAPI.Models;
using MarketsAPI.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MarketsAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReadController : ControllerBase
    {
        private readonly IReadService? readService;
        public ReadController(IReadService _readService)
        {
            readService = _readService ?? throw new ArgumentNullException(nameof(_readService), "ReadService cannot be null.");
        }

        [HttpGet]
        [Route("~/api/States")]
        public IActionResult States()
        {
            DataSet dataSet = readService!.ReadStates() ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound("No states found.");
            }
        }

        [HttpGet]
        [Route("~/api/Districts/{StateId}")]
        public IActionResult Districts(int StateId)
        {
            DataSet dataSet = readService!.ReadDistricts(StateId) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No districts found for state ID {StateId}.");
            }
        }

        [HttpGet]
        [Route("~/api/Mandals/{districtID}")]
        public IActionResult Mandals(int districtID)
        {
            DataSet dataSet = readService!.ReadMandals(districtID) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No mandals found for district ID {districtID}.");
            }
        }

        [HttpGet]
        [Route("~/api/Villages/{mandalID}")]
        public IActionResult Villages(int mandalID)
        {
            DataSet dataSet = readService!.ReadVillages(mandalID) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No villages found for mandal ID {mandalID}.");
            }
        }

        [HttpGet]
        [Route("~/api/Genders")]
        public IActionResult Genders()
        {
            DataSet dataSet = readService!.ReadGenders() ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No Genders found.");
            }
        }

        [HttpGet]
        [Route("~/api/Salutations")]
        public IActionResult Salutations()
        {
            DataSet dataSet = readService!.ReadSalutations() ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No Salutations found.");
            }
        }

        [HttpGet]
        [Route("~/api/Castes")]
        public IActionResult Castes()
        {
            DataSet dataSet = readService!.ReadCastes() ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No Castes found.");
            }
        }

        [HttpGet]
        [Route("~/api/FarmerTypes")]
        public IActionResult FarmerTypes()
        {
            DataSet dataSet = readService!.ReadFarmerType() ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No Farmer Types found.");
            }
        }

        [HttpGet]
        [Route("~/api/DistrictMarkets/{districtID}")]
        public IActionResult DistrictMarkets(int districtID)
        {
            DataSet dataSet = readService!.ReadDistrictMarkets(districtID) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No markets found for district ID {districtID}.");
            }
        }

        [HttpGet]
        [Route("~/api/Mills/{marketID}")]
        public IActionResult Mills(int marketID)
        {
            DataSet dataSet = readService!.ReadMills(marketID) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No mills found for market ID {marketID}.");
            }
        }

        [HttpGet]
        [Route("~/api/SlotInfo/{MOBILENO}")]
        public IActionResult SlotInfo(string MOBILENO)
        {
            DataSet dataSet = readService!.ReadSlotInfoFromMobileNumber(MOBILENO) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No slot information found for mobile number {MOBILENO}.");
            }
        }

        [HttpGet]
        [Route("~/api/AvailableSlots/{centerId}/{monthId}/{dayId}")]
        public IActionResult AvailableSlots(int centerId, string monthId, int dayId)
        {
            DataSet dataSet = readService!.ReadAvailableSlots(centerId, monthId, dayId) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No available slots found for center ID {centerId}, month ID {monthId}, and day ID {dayId}.");
            }
        }

        [HttpGet]
        [Route("~/api/SlotBookingInfo/{farmerId}")]
        public IActionResult SlotBookingInfo(int farmerId)
        {
            DataSet dataSet = readService!.ReadSlotBookingInfo(farmerId) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No proof details found for farmer ID {farmerId}.");
            }
        }

        [HttpGet]
        [Route("~/api/FarmerProofs/{farmerId}")]
        public IActionResult FarmerProofs(int farmerId)
        {
            DataSet dataSet = readService!.ReadFarmerUploadedProofs(farmerId) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No proof details found for farmer ID {farmerId}.");
            }
        }

        [HttpGet]
        [Route("~/api/CheckFarmerApproval/{barCode}")]
        public IActionResult CheckFarmerApproval(string barCode)
        {
            DataSet dataSet = readService!.CheckFarmerApproval(barCode) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No approval found for barcode {barCode}.");
            }
        }

        [HttpGet]
        [Route("~/api/GetFarmerDetails/{mobileNumber}")]
        public IActionResult GetFarmerDetails(string mobileNumber)
        {
            DataSet dataSet = readService!.GetFarmerDetailsWithMobileNumber(mobileNumber) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No farmer details found for barcode {mobileNumber}.");
            }
        }

        [HttpGet]
        [Route("~/api/GetFarmerDetailsByBarcode/{barCode}")]
        public IActionResult GetFarmerDetailsByBarcode(string barCode)
        {
            DataSet dataSet = readService!.GetFarmerDetailsByBarCode(barCode) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No farmer details found for barcode {barCode}.");
            }
        }

        [HttpGet]
        [Route("~/api/GetFarmerDetailsByID/{farmerId}")]
        public IActionResult GetFarmerDetailsByID(int farmerId)
        {
            DataSet dataSet = readService!.GetFarmerDetailsByID(farmerId) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No farmer details found for farmer ID {farmerId}.");
            }
        }

        [HttpGet]
        [Route("~/api/OpenSlotCount/{farmerId}")]
        public IActionResult OpenSlotCount(int farmerId)
        {
            DataSet dataSet = readService!.GetOpenSlotCount(farmerId) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No open slot count found for farmer ID {farmerId}.");
            }
        }

        [HttpGet]
        [Route("~/api/BarcodesByMobileNumber/{mobileNumber}")]
        public IActionResult BarcodesByMobileNumber(string mobileNumber)
        {
            DataSet dataSet = readService!.GetBarcodesByMobileNumber(mobileNumber) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No barcodes found for mobile number {mobileNumber}.");
            }
        }

        [HttpGet]
        [Route("~/api/UniqueNames/{stateId}")]
        public IActionResult UniqueNames(int stateId)
        {
            DataSet dataSet = readService!.GetUinqueNames(stateId) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                List<UniqueNames> uniqueNames = new List<UniqueNames>();

                if (rows.Count > 0)
                {
                    foreach (var row in rows)
                    {
                        uniqueNames.Add(new UniqueNames
                        {
                            UNIQ_ID_1_NAMING = row.ContainsKey("UNIQ_ID_1_NAMING") ? row["UNIQ_ID_1_NAMING"]?.ToString() : null,
                            UNIQ_ID_2_NAMING = row.ContainsKey("UNIQ_ID_2_NAMING") ? row["UNIQ_ID_2_NAMING"]?.ToString() : null,
                            UNIQ_ID_3_NAMING = row.ContainsKey("UNIQ_ID_3_NAMING") ? row["UNIQ_ID_3_NAMING"]?.ToString() : null,
                            UNIQ_ID_4_NAMING = row.ContainsKey("UNIQ_ID_4_NAMING") ? row["UNIQ_ID_4_NAMING"]?.ToString() : null
                        });
                    }
                }

                return Ok(uniqueNames);
            }
            else
            {
                return NotFound($"No unique names found for state ID {stateId}.");
            }
        }

        [HttpGet]
        [Route("~/api/GetFarmerProofs/{barCode}")]
        public IActionResult GetFarmerProofs(string barCode)
        {
            DataSet dataSet = readService!.GetFarmerProofsByBarcode(barCode) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No data found for barcode {barCode}.");
            }
        }

        [HttpGet]
        [Route("~/api/GetLandDetails/{barCode}")]
        public IActionResult GetLandDetails(string barCode)
        {
            DataSet dataSet = readService!.GetLandDetailsByBarcode(barCode) ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No data found for barcode {barCode}.");
            }
        }

        [HttpGet]
        [Route("~/api/GetAnnouncements")]
        public IActionResult GetAnnouncements()
        {
            DataSet dataSet = readService!.GetAnnouncements() ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No announcements found!.");
            }
        }

        [HttpGet]
        [Route("~/api/GetHelpLineNumbers")]
        public IActionResult GetHelpLineNumbers()
        {
            DataSet dataSet = readService!.GetHelpLineNumbers() ?? new DataSet();
            if (dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(table);
                return Ok(rows);
            }
            else
            {
                return NotFound($"No helpline numbers found!.");
            }
        }
    }
}