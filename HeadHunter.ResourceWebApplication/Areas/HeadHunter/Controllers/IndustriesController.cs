using HeadHunter.Model.Common;
using HeadHunter.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunter.ResourceWebApplication.Areas.HeadHunter.Controllers
{
    [ApiController]
    [Area("HeadHunter")]
    [EnableCors("CorsPolicy")]
    [Route("api/headHunter/industries")]
    public class IndustriesController : ControllerBase
    {
        private readonly HttpClients.HttpContext _context;

        public IndustriesController(HttpClients.HttpContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(ResponseModel<Industry[]>), 200)]
        public async Task<IActionResult> GetAllIndustriesAsync()
        {
            var responseModel = await _context.HeadHunter.Industries.GetIndustriesAsync();

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }
    }
}
