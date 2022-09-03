using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using HeadHunter.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunter.ResourceWebApplication.Areas.HeadHunter.Controllers
{
    [ApiController]
    [Area("HeadHunter")]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.HeadHunterDictionariesPath)]
    public class DictionariesController : ControllerBase
    {
        private readonly ILogger<DictionariesController> _logger;
        private readonly HttpClients.HttpContext _context;

        public DictionariesController(ILogger<DictionariesController> logger, HttpClients.HttpContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseModel<Dictionaries>), 200)]
        public async Task<IActionResult> GetDictionariesAsync()
        {
            var responseModel = await _context.HeadHunter.Dictionaries.GetDictionariesAsync();

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }
    }
}
