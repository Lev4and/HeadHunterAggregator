using HeadHunter.Database.MongoDb.Common;
using HeadHunter.HttpClients;
using HeadHunter.HttpClients.Resource;
using HeadHunter.Models;
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

            await ImportAreasAsync();
            await ImportDictionariesAsync();
            await ImportIndustriesAsync();
            await ImportLanguagesAsync();
            await ImportMetroAsync();
            await ImportSpecializationsAsync();
        }

        private async Task ImportAreasAsync()
        {
            _logger.LogInformation($"Import of areas");

            var areas = await _context.Resource.HeadHunterAreas.GetAllAsync();

            foreach (var area in areas.Result)
            {
                await ImportAreaAsync(area);
            }
        }

        private async Task ImportAreaAsync(Area area)
        {
            await _context.Resource.ImportAreas.ImportAsync(area);

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
                await ImportBillingTypesAsync(dictionaries.Result.VacancyBillingTypes);
                await ImportCurrenciesAsync(dictionaries.Result.Currencies);
                await ImportDriverLicenseTypesAsync(dictionaries.Result.DriverLicenseTypes);
                await ImportEmploymentsAsync(dictionaries.Result.Employments);
                await ImportExperiencesAsync(dictionaries.Result.Experiences);
                await ImportSchedulesAsync(dictionaries.Result.Schedules);
                await ImportVacancyTypesAsync(dictionaries.Result.VacancyTypes);
                await ImportWorkingDaysAsync(dictionaries.Result.WorkingDays);
                await ImportWorkingTimeIntervalsAsync(dictionaries.Result.WorkingTimeIntervals);
                await ImportWorkingTimeModesAsync(dictionaries.Result.WorkingTimeModes);
            }
        }

        private async Task ImportBillingTypesAsync(List<BillingType>? billingTypes)
        {
            _logger.LogInformation($"Import of billingTypes");

            await ImportAsync(billingTypes, _context.Resource.ImportBillingTypes);
        }

        private async Task ImportCurrenciesAsync(List<Currency>? currencies)
        {
            _logger.LogInformation($"Import of currencies");

            await ImportAsync(currencies, _context.Resource.ImportCurrencies);
        }

        private async Task ImportDriverLicenseTypesAsync(List<DriverLicenseType>? driverLicenseTypes)
        {
            _logger.LogInformation($"Import of driverLicenseTypes");

            await ImportAsync(driverLicenseTypes, _context.Resource.ImportDriverLicenseTypes);
        }

        private async Task ImportEmploymentsAsync(List<Employment>? employments)
        {
            _logger.LogInformation($"Import of employments");

            await ImportAsync(employments, _context.Resource.ImportEmployments);
        }

        private async Task ImportExperiencesAsync(List<Experience>? experiences)
        {
            _logger.LogInformation($"Import of experiences");

            await ImportAsync(experiences, _context.Resource.ImportExperiences);
        }

        private async Task ImportSchedulesAsync(List<Schedule>? schedules)
        {
            _logger.LogInformation($"Import of schedules");

            await ImportAsync(schedules, _context.Resource.ImportSchedules);
        }

        private async Task ImportVacancyTypesAsync(List<VacancyType>? vacancyTypes)
        {
            _logger.LogInformation($"Import of vacancyTypes");

            await ImportAsync(vacancyTypes, _context.Resource.ImportVacancyTypes);
        }

        private async Task ImportWorkingDaysAsync(List<WorkingDay>? workingDays)
        {
            _logger.LogInformation($"Import of workingDays");

            await ImportAsync(workingDays, _context.Resource.ImportWorkingDays);
        }

        private async Task ImportWorkingTimeIntervalsAsync(List<WorkingTimeInterval>? workingTimeIntervals)
        {
            _logger.LogInformation($"Import of workingTimeIntervals");

            await ImportAsync(workingTimeIntervals, _context.Resource.ImportWorkingTimeIntervals);
        }

        private async Task ImportWorkingTimeModesAsync(List<WorkingTimeMode>? workingTimeModes)
        {
            _logger.LogInformation($"Import of workingTimeModes");

            await ImportAsync(workingTimeModes, _context.Resource.ImportWorkingTimeModes);
        }

        private async Task ImportIndustriesAsync()
        {
            _logger.LogInformation($"Import of industries");

            await ImportAsync(_context.Resource.HeadHunterIndustries, _context.Resource.ImportIndustries);

            var industries = await _context.Resource.HeadHunterIndustries.GetAllAsync();

            if (industries.Result != null)
            {
                foreach (var industry in industries.Result)
                {
                    await ImportIndustryAsync(industry);
                }
            }
        }
        
        private async Task ImportIndustryAsync(Industry industry)
        {
            await _context.Resource.ImportIndustries.ImportAsync(industry);

            if (industry.Industries != null)
            {
                foreach (var subIndustry in industry.Industries)
                {
                    await ImportIndustryAsync(subIndustry);
                }
            }
        }

        private async Task ImportLanguagesAsync()
        {
            _logger.LogInformation("Import of languages");

            await ImportAsync(_context.Resource.HeadHunterLanguages, _context.Resource.ImportLanguages);
        }

        private async Task ImportMetroAsync()
        {
            _logger.LogInformation("Import of metro");

            var metro = await _context.Resource.HeadHunterMetro.GetAllAsync();

            if (metro != null)
            {
                foreach (var city in metro.Result)
                {
                    await ImportMetroLinesInCityAsync(city);
                }
            }
        }

        private async Task ImportMetroLinesInCityAsync(City city)
        {
            if (city.Lines != null)
            {
                foreach (var metroLine in city.Lines)
                {
                    await ImportMetroLineInCityAsync(city, metroLine);
                }
            }
        }

        private async Task ImportMetroLineInCityAsync(City city, MetroLine metroLine)
        {
            metroLine.Area = new Area { Id = city.Id, Name = city.Name };
            metroLine.AreaId = city.Id;

            await _context.Resource.ImportMetroLines.ImportAsync(metroLine);

            if (metroLine.Stations != null)
            {
                foreach (var metroStation in metroLine.Stations)
                {
                    await ImportMetroStationInMetroLineAsync(metroLine, metroStation);
                }
            }
        }

        private async Task ImportMetroStationInMetroLineAsync(MetroLine metroLine, MetroStation metroStation)
        {
            metroStation.LineId = metroLine.Id;
            metroStation.LineName = metroLine.Name;
            metroStation.StationId = metroStation.Id;
            metroStation.StationName = metroStation.Name;

            await _context.Resource.ImportMetroStations.ImportAsync(metroStation);
        }

        private async Task ImportSpecializationsAsync()
        {
            _logger.LogInformation("Import of specializations");

            var specializations = await _context.Resource.HeadHunterSpecializations.GetAllAsync();

            if (specializations != null)
            {
                foreach (var specialization in specializations.Result)
                {
                    await ImportSpecializationAsync(specialization);
                }
            }
        }

        private async Task ImportSpecializationAsync(Specialization specialization)
        {
            await _context.Resource.ImportSpecializations.ImportAsync(specialization);

            if (specialization.Specializations != null)
            {
                foreach (var subSpecialization in specialization.Specializations)
                {
                    await ImportSpecializationAsync(subSpecialization);
                }
            }
        }

        private async Task ImportAsync<TCollection, TModel>(List<TModel>? items, HttpClients.Resource.IImporter<TCollection, TModel> importer) where TCollection : ICollection where TModel : class
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    await importer.ImportAsync(item);
                }
            }
        }

        private async Task ImportAsync<TCollection, TModel>(IGetAll<TModel> storage, HttpClients.Resource.IImporter<TCollection, TModel> importer) where TCollection : ICollection where TModel : class
        {
            var items = await storage.GetAllAsync();

            if (items != null)
            {
                foreach (var item in items.Result)
                {
                    await importer.ImportAsync(item);
                }
            }
        }
    }
}
