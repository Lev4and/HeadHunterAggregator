using HeadHunter.Core.Abstracts;
using HeadHunter.Core.Extensions;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IVacancyFactory : IFactory<ResponseModels.Vacancy, Entities.Vacancy>
    {

    }

    internal class VacancyFactory : IVacancyFactory
    {
        private readonly ICompressor _compressor;

        private readonly IAreaFactory _areaFactory;
        private readonly ITestFactory _testFactory;
        private readonly ISalaryFactory _salaryFactory;
        private readonly IAddressFactory _addressFactory;
        private readonly IContactFactory _contactFactory;
        private readonly IEmployerFactory _employerFactory;
        private readonly IScheduleFactory _scheduleFactory;
        private readonly IExperienceFactory _experienceFactory;
        private readonly IEmploymentFactory _employmentFactory;
        private readonly IDepartmentFactory _departmentFactory;
        private readonly IVacancyTypeFactory _vacancyTypeFactory;
        private readonly IBillingTypeFactory _billingTypeFactory;
        private readonly IInsiderInterviewFactory _insiderInterviewFactory;

        private readonly ILanguageFactory _languageFactory;
        private readonly IKeySkillFactory _keySkillFactory;
        private readonly IWorkingDayFactory _workingDayFactory;
        private readonly ISpecializationFactory _specializationFactory;
        private readonly IWorkingTimeModeFactory _workingTimeModeFactory;
        private readonly IProfessionalRoleFactory _professionalRoleFactory;
        private readonly IDriverLicenseTypeFactory _driverLicenseTypeFactory;
        private readonly IWorkingTimeIntervalFactory _workingTimeIntervalFactory;


        public VacancyFactory(ICompressor compressor, IAreaFactory areaFactory, ITestFactory testFactory, 
            ISalaryFactory salaryFactory, IAddressFactory addressFactory, 
            IContactFactory contactFactory, IEmployerFactory employerFactory, 
            IScheduleFactory scheduleFactory, IExperienceFactory experienceFactory, 
            IEmploymentFactory employmentFactory, IDepartmentFactory departmentFactory, 
            IVacancyTypeFactory vacancyTypeFactory, IBillingTypeFactory billingTypeFactory, 
            IInsiderInterviewFactory insiderInterviewFactory, ILanguageFactory languageFactory, 
            IKeySkillFactory keySkillFactory, IWorkingDayFactory workingDayFactory, 
            ISpecializationFactory specializationFactory, IWorkingTimeModeFactory workingTimeModeFactory, 
            IProfessionalRoleFactory professionalRoleFactory, IDriverLicenseTypeFactory driverLicenseTypeFactory, 
            IWorkingTimeIntervalFactory workingTimeIntervalFactory)
        {
            _compressor = compressor;

            _areaFactory = areaFactory;
            _testFactory = testFactory;
            _salaryFactory = salaryFactory;
            _addressFactory = addressFactory;
            _contactFactory = contactFactory;
            _employerFactory = employerFactory;
            _scheduleFactory = scheduleFactory;
            _experienceFactory = experienceFactory;
            _employmentFactory = employmentFactory;
            _departmentFactory = departmentFactory;
            _vacancyTypeFactory = vacancyTypeFactory;
            _billingTypeFactory = billingTypeFactory;
            _insiderInterviewFactory = insiderInterviewFactory;

            _languageFactory = languageFactory;
            _keySkillFactory = keySkillFactory;
            _workingDayFactory = workingDayFactory;
            _specializationFactory = specializationFactory;
            _workingTimeModeFactory = workingTimeModeFactory;
            _professionalRoleFactory = professionalRoleFactory;
            _driverLicenseTypeFactory = driverLicenseTypeFactory;
            _workingTimeIntervalFactory = workingTimeIntervalFactory;
        }

        public Entities.Vacancy Create(ResponseModels.Vacancy input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new Entities.Vacancy
            {
                HasTest = input.HasTest, 
                Premium = input.Premium, 
                Archived = input.Archived,
                AcceptKids = input.AcceptKids, 
                AllowMessages = input.AllowMessages,
                AcceptTemporary = input.AcceptTemporary, 
                AcceptHandicapped = input.AcceptHandicapped,
                ResponseLetterRequired = input.ResponseLetterRequired,
                AcceptIncompleteResumes = input.AcceptIncompleteResumes, 
                HeadHunterId = long.Parse(input.Id),
                Name = input.Name, 
                Description = _compressor.Compress(input.Description),
                AlternateUrl = input.AlternateUrl, 
                ApplyAlternateUrl = input.ApplyAlternateUrl,
                BrandedDescription = _compressor.Compress(input.BrandedDescription), 
                CreatedAt = input.CreatedAt,
                PublishedAt = input.PublishedAt, 
                InitialCreatedAt = input.InitialCreatedAt, 
                Area = _areaFactory.Create(input.Area), 
                Test = _testFactory.Create(input.Test),
                Salary = _salaryFactory.Create(input.Salary), 
                Address = _addressFactory.Create(input.Address),
                Contact = _contactFactory.Create(input.Contacts), 
                Employer = _employerFactory.Create(input.Employer),
                Schedule = _scheduleFactory.Create(input.Schedule), 
                Experience = _experienceFactory.Create(input.Experience),
                Employment = _employmentFactory.Create(input.Employment), 
                Department = _departmentFactory.Create(input.Department),
                VacancyType = _vacancyTypeFactory.Create(input.Type), 
                BillingType = _billingTypeFactory.Create(input.BillingType),
                InsiderInterview = _insiderInterviewFactory.Create(input.InsiderInterview),
                Languages = _languageFactory.CreateArray(input.Languages?.ToArray()), 
                KeySkills = _keySkillFactory.CreateArray(input.KeySkills?.ToArray()),
                WorkingDays = _workingDayFactory.CreateArray(input.WorkingDays?.ToArray()),
                Specializations = _specializationFactory.CreateArray(input.Specializations?.ToArray()),
                WorkingTimeModes = _workingTimeModeFactory.CreateArray(input.WorkingTimeModes?.ToArray()),
                ProfessionalRoles = _professionalRoleFactory.CreateArray(input.ProfessionalRoles?.ToArray()),
                DriverLicenseTypes = _driverLicenseTypeFactory.CreateArray(input.DriverLicenseTypes?.ToArray()),
                WorkingTimeIntervals = _workingTimeIntervalFactory.CreateArray(input.WorkingTimeIntervals?.ToArray())
            };
        }
    }
}
