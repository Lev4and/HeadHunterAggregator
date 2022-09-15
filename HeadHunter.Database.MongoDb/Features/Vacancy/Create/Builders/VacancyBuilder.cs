using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Create.Builders
{
    public class VacancyBuilder : DocumentBuilder<Collections.Vacancy>
    {
        private readonly Models.Vacancy _vacancy;

        public VacancyBuilder(IMediator mediator, Models.Vacancy vacancy) : base(mediator)
        {
            _vacancy = vacancy;

            Document = new Collections.Vacancy(vacancy);
        }

        public VacancyBuilder WithArea()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.Area = _vacancy.Area != null ? await ImportAsync(new Area.Import.Command(_vacancy.Area)) : null;
            }));

            return this;
        }

        public VacancyBuilder WithAddress()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.Address = _vacancy.Address != null ? await ImportAsync(new Address.Import.Command(_vacancy.Address)) : null;
            }));

            return this;
        }

        public VacancyBuilder WithEmployer()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.Employer = await ImportAsync(new Employer.Import.Command(_vacancy.Employer));
            }));

            return this;
        }

        public VacancyBuilder WithSchedule()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.Schedule = _vacancy.Schedule != null ? await ImportAsync(new Schedule.Import.Command(_vacancy.Schedule)) : null;
            }));

            return this;
        }

        public VacancyBuilder WithExperience()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.Experience = _vacancy.Experience != null ? await ImportAsync(new Experience.Import.Command(_vacancy.Experience)) : null;
            }));

            return this;
        }

        public VacancyBuilder WithEmployment()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.Employment = _vacancy.Employment != null ? await ImportAsync(new Employment.Import.Command(_vacancy.Employment)) : null;
            }));

            return this;
        }

        public VacancyBuilder WithDepartment()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.Department = _vacancy.Department != null ? await ImportAsync(new Department.Import.Command(_vacancy.Department)) : null;
            }));

            return this;
        }

        public VacancyBuilder WithVacancyType()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.VacancyType = _vacancy.Type != null ? await ImportAsync(new VacancyType.Import.Command(_vacancy.Type)) : null;
            }));

            return this;
        }

        public VacancyBuilder WithBillingType()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.BillingType = _vacancy.BillingType != null ? await ImportAsync(new BillingType.Import.Command(_vacancy.BillingType)) : null;
            }));

            return this;
        }

        public VacancyBuilder WithLanguages()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.Languages = await ImportItemsAsync((item) => new Language.Import.Command(item), _vacancy.Languages);
            }));

            return this;
        }

        public VacancyBuilder WithKeySkills()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.KeySkills = await ImportItemsAsync((item) => new KeySkill.Import.Command(item), _vacancy.KeySkills);
            }));

            return this;
        }

        public VacancyBuilder WithWorkingDays()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.WorkingDays = await ImportItemsAsync((item) => new WorkingDay.Import.Command(item), _vacancy.WorkingDays);
            }));

            return this;
        }

        public VacancyBuilder WithSpecializations()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.Specializations = await ImportItemsAsync((item) => new Specialization.Import.Command(item), _vacancy.Specializations);
            }));

            return this;
        }

        public VacancyBuilder WithWorkingTimeModes()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.WorkingTimeModes = await ImportItemsAsync((item) => new WorkingTimeMode.Import.Command(item), _vacancy.WorkingTimeModes);
            }));

            return this;
        }

        public VacancyBuilder WithProfessionalRoles()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.ProfessionalRoles = await ImportItemsAsync((item) => new ProfessionalRole.Import.Command(item), _vacancy.ProfessionalRoles);
            }));

            return this;
        }

        public VacancyBuilder WithDriverLicenseTypes()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.DriverLicenseTypes = await ImportItemsAsync((item) => new DriverLicenseType.Import.Command(item), _vacancy.DriverLicenseTypes);
            }));

            return this;
        }

        public VacancyBuilder WithWorkingTimeIntervals()
        {
            Enqueue(() => Task.Run(async () =>
            {
                Document.WorkingTimeIntervals = await ImportItemsAsync((item) => new WorkingTimeInterval.Import.Command(item), _vacancy.WorkingTimeIntervals);
            }));

            return this;
        }
    }
}
