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
    [Route("api/headHunter/vacancies")]
    public class VacanciesController : ControllerBase
    {
        private readonly HttpClients.HttpContext _context;

        public VacanciesController(HttpClients.HttpContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(typeof(ResponseModel<Vacancy>), 200)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        public async Task<IActionResult> GetVacancyByIdAsync([Required][FromRoute(Name = "id")] long id)
        {
            if (id < 1)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Vacancies.GetVacancyAsync(id);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<object?>), 404)]
        [ProducesResponseType(typeof(ResponseModel<PagedResponseModel<Vacancy>>), 200)]
        public async Task<IActionResult> GetVacanciesAsync([Required][FromQuery(Name = "page")] int page, [Required][FromQuery(Name = "perPage")] int perPage, 
            [Required][FromQuery(Name = "dateFrom")] DateTime dateFrom, [Required][FromQuery(Name = "dateTo")] DateTime dateTo)
        {
            if (perPage < 1 || perPage > 100)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (page < 1 || page * perPage >= 2000)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (dateFrom > dateTo)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            if (dateTo < dateFrom)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            var responseModel = await _context.HeadHunter.Vacancies.GetVacanciesAsync(page, perPage, dateFrom, dateTo);

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }
    }
}
