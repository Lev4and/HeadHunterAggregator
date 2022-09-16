using HeadHunter.HttpClients;
using Microsoft.Extensions.Logging;

namespace HeadHunter.Importer
{
    public class InitializingImporter
    {
        private readonly ILogger<InitializingImporter> _logger;
        private readonly HttpContext _context;

        public InitializingImporter(ILogger<InitializingImporter> logger, HttpContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task InitializeAsync()
        {

        }
    }
}
