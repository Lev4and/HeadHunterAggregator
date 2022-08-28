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
    [Route(ResourceRoutes.HeadHunterKeySkillsPath)]
    public class KeySkillsController : ControllerBase
    {
        private readonly HttpClients.HttpContext _context;

        public KeySkillsController(HttpClients.HttpContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<KeySkill>>), 200)]
        public async Task<IActionResult> GetKeySkillByIdAsync([Required][FromRoute(Name = "id")] int id)
        {
            if (id < ResourceConstants.HeadHunterIdLowerValue)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.KeySkills.GetKeySkillAsync(id);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<ItemsResponseModel<KeySkill>>), 200)]
        public async Task<IActionResult> GetKeySkillsByIdsAsync([Required][FromQuery(Name = ResourceRoutes.HeadHunterKeySkillsIdQueryParam)] int[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (ids.Any(id => id < ResourceConstants.HeadHunterIdLowerValue))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.KeySkills.GetKeySkillsAsync(ids);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }
    }
}
