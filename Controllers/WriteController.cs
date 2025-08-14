using MarketsAPI.Models;
using MarketsAPI.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketsAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WriteController : Controller
    {
        private readonly IRegister? registerService;
        public WriteController(IRegister _registerService)
        {
            registerService = _registerService ?? throw new ArgumentNullException(nameof(_registerService), "ReadService cannot be null.");
        }

        [HttpPost]
        [Route("~/api/AddLand/{FarmerId}/{TotalLand}/{CottonLand}/{MARKETID}/{VILLAGEID}/{UNIQUEID}")]
        public IActionResult AddLand(int FarmerId, decimal TotalLand, decimal CottonLand, int MARKETID, int VILLAGEID, string UNIQUEID)
        {
            try
            {
                if (registerService != null)
                {
                    var result = registerService.AddLand(FarmerId, TotalLand, CottonLand,MARKETID,VILLAGEID,UNIQUEID);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Read service is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("~/api/AddLandExtended")]
        public IActionResult AddLandExtended(Land land)
        {
            try
            {
                if (registerService != null)
                {
                    var result = registerService.AddLandExtended(land);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Read service is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
