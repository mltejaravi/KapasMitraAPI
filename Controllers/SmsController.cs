using MarketsAPI.Models;
using MarketsAPI.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketsAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SmsController : Controller
    {
        private readonly ISMSService? smsService;

        public SmsController(ISMSService? _smsService)
        {
            smsService = _smsService ?? throw new ArgumentNullException(nameof(_smsService));
        }

        [HttpPost]
        public async Task<IActionResult> SendSMS([FromBody] Phone phone)
        {
            if (phone == null)
            {
                return BadRequest("Phone object cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(phone.PhoneNumber) || string.IsNullOrEmpty(phone.OTP))
            {
                return BadRequest("Phone number and OTP cannot be null or empty.");
            }

            try
            {
                var phoneNumber = phone.PhoneNumber ?? string.Empty;
                var otp = phone.OTP ?? string.Empty;

                Task<string>? task = smsService!?.SendSMS(phoneNumber, otp);
                if (task != null)
                {
                    string result = await task;
                    APIResult apiResult = new APIResult();
                    apiResult.Result = result;
                    apiResult.Status = "Success";
                    return new JsonResult(apiResult);
                }
                else
                {
                    return BadRequest("SMS service is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
