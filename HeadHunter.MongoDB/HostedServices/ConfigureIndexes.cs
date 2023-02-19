using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Entities;
using Microsoft.Extensions.Hosting;

namespace HeadHunter.MongoDB.HostedServices
{
    public class ConfigureIndexes : IHostedService
    {
        private readonly ICreatorIndexKeys _creator;

        public ConfigureIndexes(ICreatorIndexKeys creator)
        {
            _creator = creator;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _creator.CreateAsync<Address>();
            await _creator.CreateAsync<Area>();
            await _creator.CreateAsync<BillingType>();
            await _creator.CreateAsync<Contact>();
            await _creator.CreateAsync<Currency>();
            await _creator.CreateAsync<Department>();
            await _creator.CreateAsync<DriverLicenseType>();
            await _creator.CreateAsync<Employer>();
            await _creator.CreateAsync<Employment>();
            await _creator.CreateAsync<Experience>();
            await _creator.CreateAsync<Industry>();
            await _creator.CreateAsync<InsiderInterview>();
            await _creator.CreateAsync<KeySkill>();
            await _creator.CreateAsync<Language>();
            await _creator.CreateAsync<MetroLine>();
            await _creator.CreateAsync<MetroStation>();
            await _creator.CreateAsync<Phone>();
            await _creator.CreateAsync<ProfessionalRole>();
            await _creator.CreateAsync<Schedule>();
            await _creator.CreateAsync<Specialization>();
            await _creator.CreateAsync<Test>();
            await _creator.CreateAsync<Vacancy>();
            await _creator.CreateAsync<VacancyType>();
            await _creator.CreateAsync<WorkingDay>();
            await _creator.CreateAsync<WorkingTimeInterval>();
            await _creator.CreateAsync<WorkingTimeMode>();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
