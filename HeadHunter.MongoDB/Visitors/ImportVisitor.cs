using HeadHunter.MongoDB.Abstracts;
using HeadHunter.MongoDB.Core;
using HeadHunter.MongoDB.Entities;

namespace HeadHunter.MongoDB.Visitors
{
    public class ImportVisitor : IImportVisitor
    {
        private readonly IMongoDbRepository _repository;

        public ImportVisitor(IMongoDbRepository repository)
        {
            _repository = repository;
        }

        public async Task<Address> Visit(Address address)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));

            return await _repository.ImportAsync(address);
        }

        public async Task<Area> Visit(Area area)
        {
            if (area == null) throw new ArgumentNullException(nameof(area));

            var result = await _repository.ImportAsync(area);

            result.Children = result.Children
                ?.Select(childrenArea =>
                {
                    childrenArea.ParentId = result.Id;

                    return childrenArea;
                })
                ?.Select(async childrenArea => await Visit(childrenArea))
                ?.Select(task => task.Result)
                ?.ToArray();

            return result;
        }

        public async Task<BillingType> Visit(BillingType billingType)
        {
            if (billingType == null) throw new ArgumentNullException(nameof(billingType));

            return await _repository.ImportAsync(billingType);
        }

        public Task<Contact> Visit(Contact contact)
        {
            if (contact == null) throw new ArgumentNullException(nameof(contact));

            contact.PhonesIds = contact.Phones
                ?.Select(async phone => await Visit(phone))
                ?.Select(phone => phone.Result.Id)
                ?.ToArray();

            return _repository.ImportAsync(contact); 
        }

        public async Task<Currency> Visit(Currency currency)
        {
            if (currency == null) throw new ArgumentNullException(nameof(currency));
            
            return await _repository.ImportAsync(currency);
        }

        public async Task<Department> Visit(Department department)
        {
            if (department == null) throw new ArgumentNullException(nameof(department));

            return await _repository.ImportAsync(department);
        }

        public async Task<DriverLicenseType> Visit(DriverLicenseType driverLicenseType)
        {
            if (driverLicenseType == null) throw new ArgumentNullException(nameof(driverLicenseType));
            
            return await _repository.ImportAsync(driverLicenseType);
        }

        public async Task<Employer> Visit(Employer employer)
        {
            if (employer == null) throw new ArgumentNullException(nameof(employer));

            if (employer.Area != null)
            {
                employer.Area = await Visit(employer.Area);
                employer.AreaId = employer.Area.Id;
            }

            employer.IndustriesIds = employer.Industries
                ?.Select(async industry => await Visit(industry))
                ?.Select(industry => industry.Result.Id)
                ?.ToArray();

            employer.InsiderInterviewsIds = employer.InsiderInterviews
                ?.Select(async insiderInterview => await Visit(insiderInterview))
                ?.Select(insiderInterview => insiderInterview.Result.Id)
                ?.ToArray();

            return await _repository.ImportAsync(employer);
        }

        public async Task<Employment> Visit(Employment employment)
        {
            if (employment == null) throw new ArgumentNullException(nameof(employment));
            
            return await _repository.ImportAsync(employment);
        }

        public async Task<Experience> Visit(Experience experience)
        {
            if (experience == null) throw new ArgumentNullException(nameof(experience));
            
            return await _repository.ImportAsync(experience);
        }

        public async Task<Industry> Visit(Industry industry)
        {
            var result = await _repository.ImportAsync(industry);

            result.Children
                ?.Select(childrenIndustry =>
                {
                    childrenIndustry.ParentId = result.Id;

                    return childrenIndustry;
                })
                ?.Select(async childrenIndustry => await Visit(childrenIndustry))
                ?.Select(task => task.Result)
                ?.ToArray();

            return result;
        }

        public async Task<InsiderInterview> Visit(InsiderInterview insiderInterview)
        {
            if (insiderInterview == null) throw new ArgumentNullException(nameof(insiderInterview));
            
            return await _repository.ImportAsync(insiderInterview);
        }

        public async Task<KeySkill> Visit(KeySkill keySkill)
        {
            if (keySkill == null) throw new ArgumentNullException(nameof(keySkill));
            
            return await _repository.ImportAsync(keySkill);
        }

        public async Task<Language> Visit(Language language)
        {
            if (language == null) throw new ArgumentNullException(nameof(language));
            
            return await _repository.ImportAsync(language);
        }

        public async Task<MetroLine> Visit(MetroLine metroLine)
        {
            if (metroLine == null) throw new ArgumentNullException(nameof(metroLine));
            if (metroLine.Area == null) throw new ArgumentException(nameof(metroLine.Area));

            metroLine.Area = await Visit(metroLine.Area);
            metroLine.AreaId = metroLine.Area.Id;

            var result = await _repository.ImportAsync(metroLine);

            result.Stations
                ?.Select(station =>
                {
                    station.MetroLineId = result.Id;

                    return station;
                })
                ?.Select(async station => await Visit(station))
                ?.Select(task => task.Result)
                ?.ToArray();

            return result;

        }

        public async Task<MetroStation> Visit(MetroStation metroStation)
        {
            if (metroStation == null) throw new ArgumentNullException(nameof(metroStation));
            
            return await _repository.ImportAsync(metroStation);
        }

        public async Task<Phone> Visit(Phone phone)
        {
            if (phone == null) throw new ArgumentNullException(nameof(phone));
            
            return await _repository.ImportAsync(phone);
        }

        public async Task<ProfessionalRole> Visit(ProfessionalRole professionalRole)
        {
            if (professionalRole == null) throw new ArgumentNullException(nameof(professionalRole));
            
            return await _repository.ImportAsync(professionalRole);
        }

        public async Task<Schedule> Visit(Schedule schedule)
        {
            if (schedule == null) throw new ArgumentNullException(nameof(schedule));

            return await _repository.ImportAsync(schedule);
        }

        public async Task<Specialization> Visit(Specialization specialization)
        {
            if (specialization == null) throw new ArgumentNullException(nameof(specialization));

            var result = await _repository.ImportAsync(specialization);

            result.Children
                ?.Select(childrenSpecialization =>
                {
                    childrenSpecialization.ParentId = result.Id;

                    return childrenSpecialization;
                })
                ?.Select(async childrenSpecialization => await Visit(childrenSpecialization))
                ?.Select(task => task.Result)
                ?.ToArray();

            return result;
        }

        public async Task<Test> Visit(Test test)
        {
            if (test == null) throw new ArgumentNullException(nameof(test));

            return await _repository.ImportAsync(test);
        }

        public async Task<Vacancy> Visit(Vacancy vacancy)
        {
            if (vacancy == null) throw new ArgumentNullException(nameof(vacancy));

            if (vacancy.Area != null)
            {
                vacancy.Area = await Visit(vacancy.Area);
                vacancy.AreaId = vacancy.Area.Id;
            }

            if (vacancy.Test != null)
            {
                vacancy.Test = await Visit(vacancy.Test);
                vacancy.TestId = vacancy.Test.Id;
            }

            if (vacancy.Salary != null && vacancy.Salary.Currency != null)
            {
                vacancy.Salary.Currency = await Visit(vacancy.Salary.Currency);
                vacancy.Salary.CurrencyId = vacancy.Salary.Currency.Id;
            }

            if (vacancy.Address != null)
            {
                vacancy.Address = await Visit(vacancy.Address);
                vacancy.AddressId = vacancy.Address.Id;
            }

            if (vacancy.Contact != null)
            {
                vacancy.Contact = await Visit(vacancy.Contact);
                vacancy.ContactId = vacancy.Contact.Id;
            }

            if (vacancy.Employer != null)
            {
                vacancy.Employer = await Visit(vacancy.Employer);
                vacancy.EmployerId = vacancy.Employer.Id;
            }

            if (vacancy.Schedule != null)
            {
                vacancy.Schedule = await Visit(vacancy.Schedule);
                vacancy.ScheduleId = vacancy.Schedule.Id;
            }

            if (vacancy.Experience != null)
            {
                vacancy.Experience = await Visit(vacancy.Experience);
                vacancy.ExperienceId = vacancy.Experience.Id;
            }

            if (vacancy.Employment != null)
            {
                vacancy.Employment = await Visit(vacancy.Employment);
                vacancy.EmploymentId = vacancy.Employment.Id;
            }

            if (vacancy.Department != null)
            {
                vacancy.Department = await Visit(vacancy.Department);
                vacancy.DepartmentId = vacancy.Department.Id;
            }

            if (vacancy.VacancyType != null)
            {
                vacancy.VacancyType = await Visit(vacancy.VacancyType);
                vacancy.VacancyTypeId = vacancy.VacancyType.Id;
            }

            if (vacancy.BillingType != null)
            {
                vacancy.BillingType = await Visit(vacancy.BillingType);
                vacancy.BillingTypeId = vacancy.BillingType.Id;
            }

            if (vacancy.InsiderInterview != null)
            {
                vacancy.InsiderInterview = await Visit(vacancy.InsiderInterview);
                vacancy.InsiderInterviewId = vacancy.InsiderInterview.Id;
            }

            vacancy.LanguagesIds = vacancy.Languages
                ?.Select(async language => await Visit(language))
                ?.Select(language => language.Result.Id)
                ?.ToArray();

            vacancy.KeySkillsIds = vacancy.KeySkills
                ?.Select(async keySkill => await Visit(keySkill))
                ?.Select(keySkill => keySkill.Result.Id)
                ?.ToArray();

            vacancy.WorkingDaysIds = vacancy.WorkingDays
                ?.Select(async workingDay => await Visit(workingDay))
                ?.Select(workingDay => workingDay.Result.Id)
                ?.ToArray();

            vacancy.SpecializationsIds = vacancy.Specializations
                ?.Select(async specialization => await Visit(specialization))
                ?.Select(specialization => specialization.Result.Id)
                ?.ToArray();

            vacancy.WorkingTimeModesIds = vacancy.WorkingTimeModes
                ?.Select(async workingTimeModes => await Visit(workingTimeModes))
                ?.Select(workingTimeModes => workingTimeModes.Result.Id)
                ?.ToArray();

            vacancy.ProfessionalRolesIds = vacancy.ProfessionalRoles
                ?.Select(async professionalRoles => await Visit(professionalRoles))
                ?.Select(professionalRoles => professionalRoles.Result.Id)
                ?.ToArray();

            vacancy.DriverLicenseTypesIds = vacancy.DriverLicenseTypes
                ?.Select(async driverLicenseTypes => await Visit(driverLicenseTypes))
                ?.Select(driverLicenseTypes => driverLicenseTypes.Result.Id)
                ?.ToArray();

            vacancy.WorkingTimeIntervalsIds = vacancy.WorkingTimeIntervals
                ?.Select(async workingTimeInterval => await Visit(workingTimeInterval))
                ?.Select(workingTimeInterval => workingTimeInterval.Result.Id)
                ?.ToArray();

            return await _repository.ImportAsync(vacancy);
        }

        public async Task<VacancyType> Visit(VacancyType vacancyType)
        {
            if (vacancyType == null) throw new ArgumentNullException(nameof(vacancyType));
            
            return await _repository.ImportAsync(vacancyType);
        }

        public async Task<WorkingDay> Visit(WorkingDay workingDay)
        {
            if (workingDay == null) throw new ArgumentNullException(nameof(workingDay));
            
            return await _repository.ImportAsync(workingDay);
        }

        public async Task<WorkingTimeInterval> Visit(WorkingTimeInterval workingTimeInterval)
        {
            if (workingTimeInterval == null) throw new ArgumentNullException(nameof(workingTimeInterval));
            
            return await _repository.ImportAsync(workingTimeInterval);
        }

        public async Task<WorkingTimeMode> Visit(WorkingTimeMode workingTimeMode)
        {
            if (workingTimeMode == null) throw new ArgumentNullException(nameof(workingTimeMode));
            
            return await _repository.ImportAsync(workingTimeMode);
        }
    }
}
