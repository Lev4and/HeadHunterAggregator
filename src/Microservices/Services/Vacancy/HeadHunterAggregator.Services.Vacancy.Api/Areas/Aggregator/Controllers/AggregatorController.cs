using Microsoft.AspNetCore.Mvc;

namespace HeadHunterAggregator.Services.Vacancy.Api.Areas.Aggregator.Controllers
{
    [ApiController]
    [Area("aggregator")]
    [Route("api/vacancies/aggregator")]
    public class AggregatorController : ControllerBase
    {
        public AggregatorController()
        {
            
        }
    }
}
