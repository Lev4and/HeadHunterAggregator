using HeadHunter.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace HeadHunter.Importer
{
    public class VacanciesImporterActor : AbstractActor<long>
    {
        private readonly ILogger<VacanciesImporterActor> _logger;
        private readonly VacanciesImporter _importer;
        private readonly EventBus _eventBus;

        public override int ThreadCount => 20;

        public VacanciesImporterActor(ILogger<VacanciesImporterActor> logger, VacanciesImporter importer, EventBus eventBus)
        {
            _logger = logger;

            _importer = importer;
            _eventBus = eventBus;
        }

        public override async Task HandleMessage(long vacancyId)
        {
            var status = await _importer.ImportVacancyAsync(vacancyId);

            if (status)
            {
                _logger.LogInformation($"Successful import of vacancy: Id - {vacancyId}");

                await _eventBus.RaiseOnVacancyImported(vacancyId);
            }
            else _logger.LogWarning($"Vacancy is already contained in the system: Id - {vacancyId}");
        }

        public override async Task HandleError(long vacancyId, Exception ex)
        {
            _logger.LogError(ex, $"Error when import vacancy: Id: {vacancyId}");
        }
    }
}
