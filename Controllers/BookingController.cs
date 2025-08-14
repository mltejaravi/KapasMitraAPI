using MarketsAPI.Models;
using MarketsAPI.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketsAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BookingController : Controller
    {
        private IRegister? register;

        public BookingController(IRegister? _register, IConfiguration? _configuration)
        {
            register = _register ?? throw new ArgumentNullException(nameof(_register), "RegisterService cannot be null.");
        }

        [HttpPost]
        public IActionResult BookSlot([FromBody] SlotBooking booking)
        {
            try
            {
                if (register != null)
                {
                    int? result = register.RegisterSlotBooking(booking);
                    if (result != null)
                    {
                        return Ok("Booking successful!");
                    }
                    else
                    {
                        return BadRequest("Failed to book the slot.");
                    }
                }
                else
                {
                    return BadRequest("Register service is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Cancel")]
        public IActionResult CancelBooking([FromBody] CancelSlot cancelSlot)
        {
            try
            {
                if (register != null)
                {
                    int? result = register.CancelSlotBooking(cancelSlot);
                    if (result != null)
                    {
                        return Ok("Booking cancelled successfully!");
                    }
                    else
                    {
                        return BadRequest("Failed to cancel the booking.");
                    }
                }
                else
                {
                    return BadRequest("Register service is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
