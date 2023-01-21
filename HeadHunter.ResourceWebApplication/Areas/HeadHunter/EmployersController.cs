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
    [Route("api/headhunter/employers")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class EmployersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetEmployerAsync([FromRoute(Name = "id")][Required] long id)
        {
            if (id <= 0) return BadRequest($"The {nameof(id)} param should be greater than 0.");

            var result = await _mediator.Send(new GetEmployer(id));

            if (result != null) return Ok(result);
            else return NotFound();
        }
    }
}
