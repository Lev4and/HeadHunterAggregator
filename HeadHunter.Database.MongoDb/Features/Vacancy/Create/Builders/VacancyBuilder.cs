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
                var area = _vacancy.Area != null ? await ImportAsync(new Area.Import.Command(_vacancy.Area)) : null;

                Document.Area = area;
                Document.AreaId = area?.Id;
            }));

            return this;
        }

        public VacancyBuilder WithSalary()
        {
            Enqueue(() => Task.Run(async () =>
            {
                if (_vacancy.Salary != null)
                {
                    var currency = _vacancy.Salary.Currency != null ? await ImportAsync(new Currency.Import.Command(new Models.Currency() { Code = _vacancy.Salary.Currency })) : null;

                    Document.Salary.Currency = currency;
                    Document.Salary.CurrencyId = currency?.Id;
                }
            }));

            return this;
        }

        public VacancyBuilder WithEmployer()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var employer = await ImportAsync(new Employer.Import.Command(_vacancy.Employer));

                Document.Employer = employer;
                Document.EmployerId = employer.Id;
            }));

            return this;
        }

        public VacancyBuilder WithSchedule()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var schedule = _vacancy.Schedule != null ? await ImportAsync(new Schedule.Import.Command(_vacancy.Schedule)) : null;

                Document.Schedule = schedule;
                Document.ScheduleId = schedule?.Id;
            }));

            return this;
        }

        public VacancyBuilder WithExperience()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var experience = _vacancy.Experience != null ? await ImportAsync(new Experience.Import.Command(_vacancy.Experience)) : null;

                Document.Experience = experience;
                Document.ExperienceId = experience?.Id;
            }));

            return this;
        }

        public VacancyBuilder WithEmployment()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var employment = _vacancy.Employment != null ? await ImportAsync(new Employment.Import.Command(_vacancy.Employment)) : null;

                Document.Employment = employment;
                Document.EmploymentId = employment?.Id;
            }));

            return this;
        }

        public VacancyBuilder WithDepartment()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var department = _vacancy.Department != null ? await ImportAsync(new Department.Import.Command(_vacancy.Department)) : null;

                Document.Department = department;
                Document.DepartmentId = department?.Id;
            }));

            return this;
        }

        public VacancyBuilder WithVacancyType()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var vacancyType = _vacancy.Type != null ? await ImportAsync(new VacancyType.Import.Command(_vacancy.Type)) : null;

                Document.VacancyType = vacancyType;
                Document.VacancyTypeId = vacancyType?.Id;
            }));

            return this;
        }

        public VacancyBuilder WithBillingType()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var billingType = _vacancy.BillingType != null ? await ImportAsync(new BillingType.Import.Command(_vacancy.BillingType)) : null;

                Document.BillingType = billingType;
                Document.BillingTypeId = billingType?.Id;
            }));

            return this;
        }

        public VacancyBuilder WithLanguages()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var languages = await ImportItemsAsync((item) => new Language.Import.Command(item), _vacancy.Languages);

                Document.Languages = languages;
                Document.LanguagesIds = languages.Select(language => language.Id).ToList();
            }));

            return this;
        }

        public VacancyBuilder WithKeySkills()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var keySkills = await ImportItemsAsync((item) => new KeySkill.Import.Command(item), _vacancy.KeySkills);

                Document.KeySkills = keySkills;
                Document.KeySkillsIds = keySkills.Select(keySkill => keySkill.Id).ToList();
            }));

            return this;
        }

        public VacancyBuilder WithWorkingDays()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var workingDays = await ImportItemsAsync((item) => new WorkingDay.Import.Command(item), _vacancy.WorkingDays);

                Document.WorkingDays = workingDays;
                Document.WorkingDaysIds = workingDays.Select(workingDay => workingDay.Id).ToList();
            }));

            return this;
        }

        public VacancyBuilder WithSpecializations()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var specializations = await ImportItemsAsync((item) => new Specialization.Import.Command(item), _vacancy.Specializations);

                Document.Specializations = specializations;
                Document.SpecializationsIds = specializations.Select(specialization => specialization.Id).ToList();
            }));

            return this;
        }

        public VacancyBuilder WithWorkingTimeModes()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var workingTimeModes = await ImportItemsAsync((item) => new WorkingTimeMode.Import.Command(item), _vacancy.WorkingTimeModes);

                Document.WorkingTimeModes = workingTimeModes;
                Document.WorkingTimeModesIds = workingTimeModes.Select(workingTimeMode => workingTimeMode.Id).ToList();
            }));

            return this;
        }

        public VacancyBuilder WithProfessionalRoles()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var professionalRoles = await ImportItemsAsync((item) => new ProfessionalRole.Import.Command(item), _vacancy.ProfessionalRoles);

                Document.ProfessionalRoles = professionalRoles;
                Document.ProfessionalRolesIds = professionalRoles.Select(professionalRole => professionalRole.Id).ToList();
            }));

            return this;
        }

        public VacancyBuilder WithDriverLicenseTypes()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var driverLicenseTypes = await ImportItemsAsync((item) => new DriverLicenseType.Import.Command(item), _vacancy.DriverLicenseTypes);

                Document.DriverLicenseTypes = driverLicenseTypes;
                Document.DriverLicenseTypesIds = driverLicenseTypes.Select(driverLicenseType => driverLicenseType.Id).ToList();
            }));

            return this;
        }

        public VacancyBuilder WithWorkingTimeIntervals()
        {
            Enqueue(() => Task.Run(async () =>
            {
                var workingTimeIntervals = await ImportItemsAsync((item) => new WorkingTimeInterval.Import.Command(item), _vacancy.WorkingTimeIntervals);

                Document.WorkingTimeIntervals = workingTimeIntervals;
                Document.WorkingTimeIntervalsIds = workingTimeIntervals.Select(workingTimeInterval => workingTimeInterval.Id).ToList();
            }));

            return this;
        }
    }
}
