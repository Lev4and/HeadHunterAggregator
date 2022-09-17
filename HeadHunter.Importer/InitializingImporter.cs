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
            _logger.LogInformation("Initialization has started");

            //await ImportAreasAsync();
            await ImportDictionariesAsync();
        }

        private async Task ImportAreasAsync()
        {
            _logger.LogInformation($"Import of areas");

            var areas = await _context.Resource.HeadHunterAreas.GetAllAreasAsync();

            foreach (var area in areas.Result)
            {
                await ImportAreaAsync(area);
            }
        }

        private async Task ImportAreaAsync(Models.Area area)
        {
            _logger.LogInformation($"Import of area: {area.Name}");

            await _context.Resource.ImportAreas.Import(area);

            if (area.Areas != null)
            {
                foreach (var region in area.Areas)
                {
                    await ImportAreaAsync(region);
                }
            }
        }

        private async Task ImportDictionariesAsync()
        {
            _logger.LogInformation($"Import of dictionaries");

            var dictionaries = await _context.HeadHunter.Dictionaries.GetDictionariesAsync();

            if (dictionaries.Result != null)
            {
                await ImportBillingTypesAsync(dictionaries.Result.VacancyBillingType);
                await ImportCurrenciesAsync(dictionaries.Result.Currency);
                await ImportDriverLicenseTypesAsync(dictionaries.Result.DriverLicenseTypes);
                await ImportEmploymentsAsync(dictionaries.Result.Employment);
                await ImportExperiencesAsync(dictionaries.Result.Experience);
                await ImportSchedulesAsync(dictionaries.Result.Schedule);
                await ImportVacancyTypesAsync(dictionaries.Result.VacancyType);
                await ImportWorkingDaysAsync(dictionaries.Result.WorkingDays);
                await ImportWorkingTimeIntervalsAsync(dictionaries.Result.WorkingTimeIntervals);
                await ImportWorkingTimeModesAsync(dictionaries.Result.WorkingTimeModes);
            }
        }

        private async Task ImportBillingTypesAsync(List<Models.VacancyBillingType>? billingTypes)
        {
            _logger.LogInformation($"Import of billingTypes");

            if (billingTypes != null)
            {
                foreach (var billingType in billingTypes)
                {
                    await _context.Resource.ImportBillingTypes.Import(new Models.BillingType { Id = billingType.Id, Name = billingType.Name });
                }
            }
        }

        private async Task ImportCurrenciesAsync(List<Models.Currency>? currencies)
        {
            _logger.LogInformation($"Import of currencies");

            if (currencies != null)
            {
                foreach(var currency in currencies)
                {
                    await _context.Resource.ImportCurrencies.Import(currency);
                }
            }
        }

        private async Task ImportDriverLicenseTypesAsync(List<Models.DriverLicenseType>? driverLicenseTypes)
        {
            _logger.LogInformation($"Import of driverLicenseTypes");

            if (driverLicenseTypes != null)
            {
                foreach (var driverLicenseType in driverLicenseTypes)
                {
                    await _context.Resource.ImportDriverLicenseTypes.Import(driverLicenseType);
                }
            }
        }

        private async Task ImportEmploymentsAsync(List<Models.Employment>? employments)
        {
            _logger.LogInformation($"Import of employments");

            if (employments != null)
            {
                foreach (var employment in employments)
                {
                    await _context.Resource.ImportEmployments.Import(employment);
                }
            }
        }

        private async Task ImportExperiencesAsync(List<Models.Experience>? experiences)
        {
            _logger.LogInformation($"Import of experiences");

            if (experiences != null)
            {
                foreach (var experience in experiences)
                {
                    await _context.Resource.ImportExperiences.Import(experience);
                }
            }
        }

        private async Task ImportSchedulesAsync(List<Models.Schedule>? schedules)
        {
            _logger.LogInformation($"Import of schedules");

            if (schedules != null)
            {
                foreach (var schedule in schedules)
                {
                    await _context.Resource.ImportSchedules.Import(schedule);
                }
            }
        }

        private async Task ImportVacancyTypesAsync(List<Models.VacancyType>? vacancyTypes)
        {
            _logger.LogInformation($"Import of vacancyTypes");

            if (vacancyTypes != null)
            {
                foreach (var vacancyType in vacancyTypes)
                {
                    await _context.Resource.ImportVacancyTypes.Import(vacancyType);
                }
            }
        }

        private async Task ImportWorkingDaysAsync(List<Models.WorkingDay>? workingDays)
        {
            _logger.LogInformation($"Import of workingDays");

            if (workingDays != null)
            {
                foreach (var workingDay in workingDays)
                {
                    await _context.Resource.ImportWorkingDays.Import(workingDay);
                }
            }
        }

        private async Task ImportWorkingTimeIntervalsAsync(List<Models.WorkingTimeInterval>? workingTimeIntervals)
        {
            _logger.LogInformation($"Import of workingTimeIntervals");

            if (workingTimeIntervals != null)
            {
                foreach (var workingTimeInterval in workingTimeIntervals)
                {
                    await _context.Resource.ImportWorkingTimeIntervals.Import(workingTimeInterval);
                }
            }
        }

        private async Task ImportWorkingTimeModesAsync(List<Models.WorkingTimeMode>? workingTimeModes)
        {
            _logger.LogInformation($"Import of workingTimeModes");

            if (workingTimeModes != null)
            {
                foreach (var workingTimeMode in workingTimeModes)
                {
                    await _context.Resource.ImportWorkingTimeModes.Import(workingTimeMode);
                }
            }
        }
    }
}
