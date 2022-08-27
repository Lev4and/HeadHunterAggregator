﻿using HeadHunter.Model.Common;
using HeadHunter.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunter.ResourceWebApplication.Areas.HeadHunter.Controllers
{
    [ApiController]
    [Area("HeadHunter")]
    [EnableCors("CorsPolicy")]
    [Route("api/headHunter/languages")]
    public class LanguagesController : ControllerBase
    {
        private readonly HttpClients.HttpContext _context;

        public LanguagesController(HttpClients.HttpContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(ResponseModel<Language[]>), 200)]
        public async Task<IActionResult> GetAllLanguagesAsync()
        {
            var responseModel = await _context.HeadHunter.Languages.GetLanguagesAsync();

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }
    }
}
