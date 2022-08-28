using HeadHunter.HttpClients.HeadHunter.ResponseModels;
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
    [Route(ResourceRoutes.HeadHunterSuggestsPath)]
    public class SuggestsController : ControllerBase
    {
        private readonly HttpClients.HttpContext _context;

        public SuggestsController(HttpClients.HttpContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route(ResourceRoutes.HeadHunterSuggestsAreasQuery)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<Area>>), 200)]
        public async Task<IActionResult> GetSuggestsAreaLeavesAsync([Required][FromQuery(Name = ResourceRoutes.HeadHunterSuggestsSearchStringQueryParam)] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (searchString.Length < ResourceConstants.HeadHunterMinLengthSearchString)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Suggests.GetSuggestsAreaLeavesAsync(searchString);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [Route(ResourceRoutes.HeadHunterSuggestsCompaniesQuery)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<Employer>>), 200)]
        public async Task<IActionResult> GetSuggestsCompaniesLeavesAsync([Required][FromQuery(Name = ResourceRoutes.HeadHunterSuggestsSearchStringQueryParam)] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (searchString.Length < ResourceConstants.HeadHunterMinLengthSearchString)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Suggests.GetSuggestsCompaniesLeavesAsync(searchString);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [Route(ResourceRoutes.HeadHunterSuggestsUniversitiesQuery)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<University>>), 200)]
        public async Task<IActionResult> GetSuggestsUniversitiesAsync([Required][FromQuery(Name = ResourceRoutes.HeadHunterSuggestsSearchStringQueryParam)] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (searchString.Length < ResourceConstants.HeadHunterMinLengthSearchString)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Suggests.GetSuggestsUniversitiesAsync(searchString);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [Route(ResourceRoutes.HeadHunterSuggestsSpecializationsQuery)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<Specialization>>), 200)]
        public async Task<IActionResult> GetSuggestsSpecializationsAsync([Required][FromQuery(Name = ResourceRoutes.HeadHunterSuggestsSearchStringQueryParam)] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (searchString.Length < ResourceConstants.HeadHunterMinLengthSearchString)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Suggests.GetSuggestsSpecializationsAsync(searchString);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [Route(ResourceRoutes.HeadHunterSuggestsProfessionalRolesQuery)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<ProfessionalRole>>), 200)]
        public async Task<IActionResult> GetSuggestsProfessionalRolesAsync([Required][FromQuery(Name = ResourceRoutes.HeadHunterSuggestsSearchStringQueryParam)] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (searchString.Length < ResourceConstants.HeadHunterMinLengthSearchString)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Suggests.GetSuggestsProfessionalRolesAsync(searchString);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [Route(ResourceRoutes.HeadHunterSuggestsKeySkillsQuery)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<KeySkill>>), 200)]
        public async Task<IActionResult> GetSuggestsKeySkillsAsync([Required][FromQuery(Name = ResourceRoutes.HeadHunterSuggestsSearchStringQueryParam)] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (searchString.Length < ResourceConstants.HeadHunterMinLengthSearchString)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Suggests.GetSuggestsKeySkillsAsync(searchString);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [Route(ResourceRoutes.HeadHunterSuggestsVacancyPositionsQuery)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<VacancyPosition>>), 200)]
        public async Task<IActionResult> GetSuggestsVacancyPositionsAsync([Required][FromQuery(Name = ResourceRoutes.HeadHunterSuggestsSearchStringQueryParam)] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (searchString.Length < ResourceConstants.HeadHunterMinLengthSearchString)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Suggests.GetSuggestsVacancyPositionsAsync(searchString);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [Route(ResourceRoutes.HeadHunterSuggestsVacancyKeyWordsQuery)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<KeyWord>>), 200)]
        public async Task<IActionResult> GetSuggestsVacancyKeyWordsAsync([Required][FromQuery(Name = ResourceRoutes.HeadHunterSuggestsSearchStringQueryParam)] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (searchString.Length < ResourceConstants.HeadHunterMinLengthSearchString)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Suggests.GetSuggestsVacancyKeyWordsAsync(searchString);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }
    }
}
