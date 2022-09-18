using HeadHunter.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace HeadHunter.Importer
{
    public class VacanciesImporterActor : AbstractActor<Vacancy>
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

        public override async Task HandleMessage(Vacancy vacancy)
        {
            var vacancyId = Convert.ToInt64(vacancy.Id);
            var companyId = Convert.ToInt64(vacancy.Employer.Id);

            var importedVacancy = await _importer.ImportVacancyAsync(vacancyId, companyId);

            await _eventBus.RaiseOnVacancyImported(importedVacancy);
        }

        public override async Task HandleError(Vacancy vacancy, Exception ex)
        {
            _logger.LogError(ex, $"Error when import vacancy: Id: {vacancy.Id} EmployerId: {vacancy.Employer.Id}");
        }
    }
}
