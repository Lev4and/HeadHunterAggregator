using HeadHunter.Models;
using System.Diagnostics;

namespace HeadHunter.Importer
{
    public class VacanciesImporterActor : AbstractActor<Vacancy>
    {
        private readonly VacanciesImporter _importer;
        private readonly EventBus _eventBus;

        public override int ThreadCount => 20;

        public VacanciesImporterActor(VacanciesImporter importer, EventBus eventBus)
        {
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
            Debug.WriteLine($"Error handling {vacancy.Id} with error {ex.Message}");

            await Task.Delay(1000);

            await SendAsync(vacancy);
        }
    }
}
