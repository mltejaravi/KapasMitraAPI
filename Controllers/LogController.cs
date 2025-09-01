using MarketsAPI.Models;
using MarketsAPI.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketsAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LogController : Controller
    {
        private IRegister? register;
        public LogController(IRegister? _register, IConfiguration? _configuration)
        {
            register = _register ?? throw new ArgumentNullException(nameof(_register), "RegisterService cannot be null.");
        }

        [HttpPost]
        public IActionResult CreateLog(ActivityLog log)
        {
            try
            {
                if (register != null)
                {
                    int? result = register.CreateLog(log);
                    if (result != null)
                    {
                        return Ok("Log created successful!");
                    }
                    else
                    {
                        return BadRequest("Failed to book the log.");
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