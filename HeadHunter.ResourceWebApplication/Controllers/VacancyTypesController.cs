using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collections = HeadHunter.Database.MongoDb.Collections;
using VacancyType = HeadHunter.Database.MongoDb.Features.VacancyType;

namespace HeadHunter.ResourceWebApplication.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.VacancyTypesPath)]
    public class VacancyTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VacancyTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(ResourceRoutes.VacancyTypesAllQuery)]
        [ProducesResponseType(typeof(ResponseModel<List<Collections.VacancyType>>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new ResponseModel<List<Collections.VacancyType>>(await _mediator.Send(new VacancyType.GetAll.Command()), ResponseStatuses.Success));
        }
    }
}
