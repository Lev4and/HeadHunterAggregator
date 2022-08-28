using HeadHunter.HttpClients.Resource;
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
    [Route(ResourceRoutes.HeadHunterMetroPath)]
    public class MetroController : ControllerBase
    {
        private readonly HttpClients.HttpContext _context;

        public MetroController(HttpClients.HttpContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route(ResourceRoutes.HeadHunterMetroAllQuery)]
        [ProducesResponseType(typeof(ResponseModel<City[]>), 200)]
        public async Task<IActionResult> GetAllStationsMetroAsync()
        {
            var responseModel = await _context.HeadHunter.Metro.GetAllStationsMetroAsync();

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseModel<City>), 200)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        public async Task<IActionResult> GetAllStationsMetroByCityIdAsync([Required][FromQuery(Name = ResourceRoutes.HeadHunterMetroAllStationsCityIdQueryParam)] int cityId)
        {
            if (cityId < ResourceConstants.HeadHunterIdLowerValue)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Metro.GetAllStationsMetroByCityIdAsync(cityId);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }
    }
}
