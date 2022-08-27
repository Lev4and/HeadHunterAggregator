using HeadHunter.HttpClients.HeadHunter.ResponseModels;
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
    [Route("api/headHunter/universities")]
    public class UniversitiesController : ControllerBase
    {
        private readonly HttpClients.HttpContext _context;

        public UniversitiesController(HttpClients.HttpContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<University>>), 200)]
        public async Task<IActionResult> GetUniversityByIdAsync([Required][FromRoute(Name = "id")] int id)
        {
            if (id < 1)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Universities.GetUniversityAsync(id);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<University>>), 200)]
        public async Task<IActionResult> GetUniversitiesByIdsAsync([Required][FromQuery(Name = "id")] int[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (ids.Any(id => id < 1))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Universities.GetUniversitiesAsync(ids);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [Route("{id:int}/faculties")]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<Faculty[]>), 200)]
        public async Task<IActionResult> GetAllFacultiesByUniversityIdAsync([Required][FromRoute(Name = "universityId")] int universityId)
        {
            if (universityId < 1)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Universities.GetAllFacultiesByUniversityIdAsync(universityId);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }
    }
}
