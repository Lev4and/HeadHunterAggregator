﻿using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using HeadHunter.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunter.ResourceWebApplication.Areas.HeadHunter.Controllers
{
    [ApiController]
    [Area("HeadHunter")]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.HeadHunterCountriesPath)]
    public class CountriesController : ControllerBase
    {
        private readonly HttpClients.HttpContext _context;

        public CountriesController(HttpClients.HttpContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route(ResourceRoutes.HeadHunterCountriesAllQuery)]
        [ProducesResponseType(typeof(ResponseModel<Country[]>), 200)]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            var responseModel = await _context.HeadHunter.Areas.GetAllCountriesAsync();

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }
    }
}
