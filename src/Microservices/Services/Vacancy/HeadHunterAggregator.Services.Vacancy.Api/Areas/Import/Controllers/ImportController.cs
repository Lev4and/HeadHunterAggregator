using HeadHunterAggregator.Infrastructure.Web.Http;
using HeadHunterAggregator.Services.Vacancy.UseCases.Commands;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace HeadHunterAggregator.Services.Vacancy.Api.Areas.Import.Controllers
{
    [ApiController]
    [Area("import")]
    [Route("api/vacancies/import")]
    public class ImportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ImportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("areas")]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ImportAreasAsync([Required][FromBody] IReadOnlyCollection<AreaDto> areas, 
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new ImportHeadHunterAreasCommand(areas), cancellationToken));
        }

        [HttpPost]
        [Route("dictionaries")]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ImportDictionariesAsync([Required][FromBody] DictionariesDto dictionaries,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new ImportHeadHunterDictionariesCommand(dictionaries), cancellationToken));
        }

        [HttpPost]
        [Route("employer")]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ImportEmployerAsync([Required][FromBody] EmployerDto employer,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new ImportHeadHunterEmployerCommand(employer), cancellationToken));
        }

        [HttpPost]
        [Route("industries")]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ImportIndustriesAsync([Required][FromBody] IReadOnlyCollection<IndustryDto> industries,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new ImportHeadHunterIndustriesCommand(industries), cancellationToken));
        }

        [HttpPost]
        [Route("languages")]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ImportLanguagesAsync([Required][FromBody] IReadOnlyCollection<LanguageDto> languages,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new ImportHeadHunterLanguagesCommand(languages), cancellationToken));
        }

        [HttpPost]
        [Route("metro")]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ImportMetroAsync([Required][FromBody] IReadOnlyCollection<CityDto> cities,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new ImportHeadHunterMetroCommand(cities), cancellationToken));
        }

        [HttpPost]
        [Route("specializations")]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ImportSpecializationsAsync([Required][FromBody] IReadOnlyCollection<SpecializationDto> specializations,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new ImportHeadHunterSpecializationsCommand(specializations), cancellationToken));
        }

        [HttpPost]
        [Route("vacancy")]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ImportVacancyAsync([Required][FromBody] VacancyDto vacancy,
            CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new ImportHeadHunterVacancyCommand(vacancy), cancellationToken));
        }
    }
}
