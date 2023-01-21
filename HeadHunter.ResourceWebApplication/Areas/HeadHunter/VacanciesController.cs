using HeadHunter.Infrastructure.Queries.HeadHunter;
using HeadHunter.ResourceWebApplication.Extensions;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HeadHunter.ResourceWebApplication.Areas.HeadHunter
{
    [ApiController]
    [Area("HeadHunter")]
    [Route("api/headhunter/vacancies")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class VacanciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VacanciesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetVacanciesAsync([FromQuery(Name = "page")][Required] int page,
            [FromQuery(Name = "perPage")][Required] int perPage, [FromQuery(Name = "dateFrom")][Required] DateTime dateFrom,
            [FromQuery(Name = "dateTo")][Required] DateTime dateTo)
        {
            if (page < 1 || page * perPage > 1999) return BadRequest($"The {nameof(page)} param should be greater than 0 " +
                $"and equal expression {nameof(page)} * {nameof(perPage)} <= 1999.");
            if (perPage < 1 || perPage > 100) return BadRequest($"The {nameof(perPage)} param should be be greater than 0 " +
                $"and less or equal than 100.");
            if (dateFrom > dateTo) return BadRequest($"The {nameof(dateFrom)} param should be less than or equal " +
                $"{nameof(dateTo)} param.");
            if (dateTo < dateFrom) return BadRequest($"The {nameof(dateTo)} param should be geater than or equal " +
                $"{nameof(dateFrom)} param.");

            return Ok(await _mediator.Send(new GetVacancies(page, perPage, dateFrom, dateTo)));
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetVacancyAsync([FromRoute(Name = "id")][Required] long id)
        {
            if (id <= 0) return BadRequest($"The {nameof(id)} param should be greater than 0.");

            var result = await _mediator.Send(new GetVacancy(id));

            if (result != null) return Ok(result);
            else return NotFound();
        }
    }
}
