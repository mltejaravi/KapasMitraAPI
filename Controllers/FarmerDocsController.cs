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
    public class FarmerDocsController : Controller
    {
        private IRegister? register;

        public FarmerDocsController(IRegister? _register, IConfiguration? _configuration)
        {
            register = _register ?? throw new ArgumentNullException(nameof(_register), "RegisterService cannot be null.");
        }

        [HttpPost]
        public IActionResult SaveDocs([FromBody] FarmerDocuments farmerDocuments)
        {
            try
            {
                if (register != null)
                {
                    int? result = register.RegisterFarmerDocuments(farmerDocuments);
                    if (result != null)
                    {
                        return Ok("Saved a document!");
                    }
                    else
                    {
                        return BadRequest("Failed to save the document.");
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
