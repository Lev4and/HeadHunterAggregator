using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Collections = HeadHunter.Database.MongoDb.Collections;
using Currency = HeadHunter.Database.MongoDb.Features.Currency;

namespace HeadHunter.ResourceWebApplication.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.CurrenciesPath)]
    public class CurrenciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CurrenciesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(ResourceRoutes.CurrenciesAllQuery)]
        [ProducesResponseType(typeof(ResponseModel<List<Collections.Currency>>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new ResponseModel<List<Collections.Currency>>(await _mediator.Send(new Currency.GetAll.Command()), ResponseStatuses.Success));
        }
    }
}
