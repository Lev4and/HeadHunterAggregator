using HeadHunter.Model.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunter.ResourceWebApplication.Controllers
{
    [ApiController]
    [Route("api/error")]
    [EnableCors("CorsPolicy")]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        [Route("badRequest")]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        public new IActionResult BadRequest()
        {
            return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
        }
    }
}
