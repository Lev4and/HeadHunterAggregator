using HeadHunter.MongoDB.Entities;

namespace HeadHunter.MongoDB.Abstracts
{
    public interface IImportVisitor
    {
        Task<Address> Visit(Address address);

        Task<Area> Visit(Area area);

        Task<BillingType> Visit(BillingType billingType);

        Task<Contact> Visit(Contact contact);

        Task<Currency> Visit(Currency currency);

        Task<Department> Visit(Department department);

        Task<DriverLicenseType> Visit(DriverLicenseType licenseType);

        Task<Employer> Visit(Employer employer);

        Task<Employment> Visit(Employment employment);

        Task<Experience> Visit(Experience experience);

        Task<Industry> Visit(Industry industry);

        Task<InsiderInterview> Visit(InsiderInterview insiderInterview);

        Task<KeySkill> Visit(KeySkill keySkill);

        Task<Language> Visit(Language language);

        Task<MetroLine> Visit(MetroLine metroLine);

        Task<MetroStation> Visit(MetroStation metroStation);

        Task<Phone> Visit(Phone phone);

        Task<ProfessionalRole> Visit(ProfessionalRole professionalRole);

        Task<Schedule> Visit(Schedule schedule);

        Task<Specialization> Visit(Specialization specialization);

        Task<Test> Visit(Test test);

        Task<Vacancy> Visit(Vacancy vacancy);

        Task<VacancyType> Visit(VacancyType vacancyType);

        Task<WorkingDay> Visit(WorkingDay workingDay);

        Task<WorkingTimeInterval> Visit(WorkingTimeInterval workingTimeInterval);

        Task<WorkingTimeMode> Visit(WorkingTimeMode workingTimeMode);
    }
}
