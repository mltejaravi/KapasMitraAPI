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
    public class RegisterController : ControllerBase
    {
        private IRegister? register;

        public RegisterController(IRegister? _register, IConfiguration? _configuration)
        {
            register = _register ?? throw new ArgumentNullException(nameof(_register), "RegisterService cannot be null.");
        }

        [HttpPost]
        public IActionResult Register([FromBody] Farmer farmer)
        {
            try
            {
                if (register != null)
                {
                    DataTable result = register.RegisterFarmer(farmer);
                    List<Dictionary<string, object?>> rows = Services.Services.ConvertToDictionary(result);
                    return Ok(rows);
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