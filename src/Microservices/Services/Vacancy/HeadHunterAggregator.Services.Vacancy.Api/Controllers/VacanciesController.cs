using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunterAggregator.Services.Vacancy.Api.Controllers
{
    [ApiController]
    [Route("api/vacancies")]
    public class VacanciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VacanciesController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
