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
    [Route("api/headHunter/suggests")]
    public class SuggestsController : ControllerBase
    {
        private readonly HttpClients.HttpContext _context;

        public SuggestsController(HttpClients.HttpContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("areas")]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<Area>>), 200)]
        public async Task<IActionResult> GetSuggestsAreaLeavesAsync([Required][FromQuery(Name = "q")] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (searchString.Length <= 2)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Suggests.GetSuggestsAreaLeavesAsync(searchString);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [Route("companies")]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<Employer>>), 200)]
        public async Task<IActionResult> GetSuggestsCompaniesLeavesAsync([Required][FromQuery(Name = "q")] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (searchString.Length <= 2)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Suggests.GetSuggestsCompaniesLeavesAsync(searchString);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [Route("universities")]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<University>>), 200)]
        public async Task<IActionResult> GetSuggestsUniversitiesAsync([Required][FromQuery(Name = "q")] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (searchString.Length <= 2)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Suggests.GetSuggestsUniversitiesAsync(searchString);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [Route("specializations")]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<Specialization>>), 200)]
        public async Task<IActionResult> GetSuggestsSpecializationsAsync([Required][FromQuery(Name = "q")] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (searchString.Length <= 2)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Suggests.GetSuggestsSpecializationsAsync(searchString);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [Route("professionalRoles")]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<ProfessionalRole>>), 200)]
        public async Task<IActionResult> GetSuggestsProfessionalRolesAsync([Required][FromQuery(Name = "q")] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (searchString.Length <= 2)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Suggests.GetSuggestsProfessionalRolesAsync(searchString);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [Route("keySkills")]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<KeySkill>>), 200)]
        public async Task<IActionResult> GetSuggestsKeySkillsAsync([Required][FromQuery(Name = "q")] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (searchString.Length <= 2)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Suggests.GetSuggestsKeySkillsAsync(searchString);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [Route("vacancyPositions")]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<VacancyPosition>>), 200)]
        public async Task<IActionResult> GetSuggestsVacancyPositionsAsync([Required][FromQuery(Name = "q")] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (searchString.Length <= 2)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Suggests.GetSuggestsVacancyPositionsAsync(searchString);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [Route("vacancyKeyWords")]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<KeyWord>>), 200)]
        public async Task<IActionResult> GetSuggestsVacancyKeyWordsAsync([Required][FromQuery(Name = "q")] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (searchString.Length <= 2)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Suggests.GetSuggestsVacancyKeyWordsAsync(searchString);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }
    }
}
