using HeadHunterAggregator.Infrastructure.Web.Http;
using HeadHunterAggregator.Services.Vacancy.UseCases.Queries;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace HeadHunterAggregator.Services.Vacancy.Api.Areas.HeadHunter.Controllers
{
    [ApiController]
    [Area("headHunter")]
    [Route("api/vacancies/headHunter/")]
    public class HeadHunterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HeadHunterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("areas")]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyCollection<AreaDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAreasAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetHeadHunterAreasQuery(), cancellationToken));
        }

        [HttpGet]
        [Route("dictionaries")]
        [ProducesResponseType(typeof(ApiResponse<DictionariesDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDictionariesAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetHeadHunterDictionariesQuery(), cancellationToken));
        }

        [HttpGet]
        [Route("employer/{id:long:min(1):required}")]
        [ProducesResponseType(typeof(ApiResponse<EmployerDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetEmployerAsync([Required][FromRoute(Name = "id")] long id, 
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetHeadHunterEmployerQuery(id), cancellationToken));
        }

        [HttpGet]
        [Route("industries")]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyCollection<IndustryDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetIndustriesAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetHeadHunterIndustriesQuery(), cancellationToken));
        }

        [HttpGet]
        [Route("languages")]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyCollection<LanguageDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLanguagesAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetHeadHunterLanguagesQuery(), cancellationToken));
        }

        [HttpGet]
        [Route("metro")]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyCollection<CityDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMetroAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetHeadHunterMetroQuery(), cancellationToken));
        }

        [HttpGet]
        [Route("specializations")]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyCollection<SpecializationDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetSpecializationsAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetHeadHunterSpecializationsQuery(), cancellationToken));
        }

        [HttpGet]
        [Route("vacancies")]
        [ProducesResponseType(typeof(ApiResponse<PagedResponseModelDto<VacancyDto>>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetVacanciesAsync([Required][FromQuery(Name = "page")] int page,
            [Required][FromQuery(Name = "per_page")] int perPage, [Required][FromQuery(Name = "date_from")] DateTime dateFrom,
                [Required][FromQuery(Name = "date_to")] DateTime dateTo, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetHeadHunterVacanciesQuery(page, perPage, dateFrom, dateTo), cancellationToken));
        }

        [HttpGet]
        [Route("vacancies/{id:long:min(1):required}")]
        [ProducesResponseType(typeof(ApiResponse<VacancyDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetVacancyAsync([Required][FromRoute(Name = "id")] long id,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetHeadHunterVacancyQuery(id), cancellationToken));
        }
    }
}
