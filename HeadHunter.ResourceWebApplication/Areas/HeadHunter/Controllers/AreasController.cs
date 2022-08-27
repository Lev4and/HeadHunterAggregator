using HeadHunter.Model.Common;
using HeadHunter.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HeadHunter.ResourceWebApplication.Areas.HeadHunter.Controllers
{
    [ApiController]
    [Area("HeadHunter")]
    [EnableCors("CorsPolicy")]
    [Route("api/headHunter/areas")]
    public class AreasController : ControllerBase
    {
        private readonly HttpClients.HttpContext _context;

        public AreasController(HttpClients.HttpContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(ResponseModel<Area[]>), 200)]
        public async Task<IActionResult> GetAllAreasAsync()
        {
            var responseModel = await _context.HeadHunter.Areas.GetAllAreasAsync();

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ResponseModel<Area>), 200)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        public async Task<IActionResult> GetAreaByIdAsync([Required][FromRoute(Name = "id")] int id)
        {
            if (id < 1)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Areas.GetAreaAsync(id);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }
    }
}
