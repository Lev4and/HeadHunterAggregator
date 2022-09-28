using HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions;
using HeadHunter.Database.MongoDb.Common;
using Microsoft.Extensions.Hosting;

namespace HeadHunter.Database.MongoDb
{
    public class ConfigureMongoDbIndexesService : IHostedService
    {
        private readonly Repository _repository;

        public ConfigureMongoDbIndexesService(Repository repository)
        {
            _repository = repository;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await CreateIndexKeysAsync(new AreaIndexKeysDefinition());
            await CreateIndexKeysAsync(new BillingTypeIndexKeysDefinition());
            await CreateIndexKeysAsync(new CurrencyIndexKeysDefinition());
            await CreateIndexKeysAsync(new DepartmentIndexKeysDefinition());
            await CreateIndexKeysAsync(new DriverLicenseTypeIndexKeysDefinition());
            await CreateIndexKeysAsync(new EmployerIndexKeysDefinition());
            await CreateIndexKeysAsync(new EmploymentIndexKeysDefinition());
            await CreateIndexKeysAsync(new ExperienceIndexKeysDefinition());
            await CreateIndexKeysAsync(new IndustryIndexKeysDefinition());
            await CreateIndexKeysAsync(new KeySkillIndexKeysDefinition());
            await CreateIndexKeysAsync(new LanguageIndexKeysDefinition());
            await CreateIndexKeysAsync(new MetroLineIndexKeysDefinition());
            await CreateIndexKeysAsync(new MetroStationIndexKeysDefinition());
            await CreateIndexKeysAsync(new ProfessionalRoleIndexKeysDefinition());
            await CreateIndexKeysAsync(new ScheduleIndexKeysDefinition());
            await CreateIndexKeysAsync(new SpecializationIndexKeysDefinition());
            await CreateIndexKeysAsync(new VacancyIndexKeysDefinition());
            await CreateIndexKeysAsync(new VacancyTypeIndexKeysDefinition());
            await CreateIndexKeysAsync(new WorkingDayIndexKeysDefinition());
            await CreateIndexKeysAsync(new WorkingTimeIntervalIndexKeysDefinition());
            await CreateIndexKeysAsync(new WorkingTimeModeIndexKeysDefinition());
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        private async Task CreateIndexKeysAsync<TCollection>(IDefiningIndexKeys<TCollection> definingIndexKeys) where TCollection : ICollection
        {
            await _repository.CreateIndexKeysAsync(definingIndexKeys);
        }
    }
}
