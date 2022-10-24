using HeadHunter.Database.MongoDb.Collections;

namespace HeadHunter.HttpClients.Resource
{
    public class ResourceHttpContext
    {
        public HeadHunterAreasHttpClient HeadHunterAreas => new HeadHunterAreasHttpClient();

        public HeadHunterCompaniesHttpClient HeadHunterCompanies => new HeadHunterCompaniesHttpClient();

        public HeadHunterCountriesHttpClient HeadHunterCountries => new HeadHunterCountriesHttpClient();

        public HeadHunterDictionariesHttpClient HeadHunterDictionaries => new HeadHunterDictionariesHttpClient();

        public HeadHunterIndustriesHttpClient HeadHunterIndustries => new HeadHunterIndustriesHttpClient();

        public HeadHunterKeySkillsHttpClient HeadHunterKeySkills => new HeadHunterKeySkillsHttpClient();

        public HeadHunterLanguagesHttpClient HeadHunterLanguages => new HeadHunterLanguagesHttpClient();

        public HeadHunterMetroHttpClient HeadHunterMetro => new HeadHunterMetroHttpClient();

        public HeadHunterSpecializationsHttpClient HeadHunterSpecializations => new HeadHunterSpecializationsHttpClient();

        public HeadHunterSuggestsHttpClient HeadHunterSuggests => new HeadHunterSuggestsHttpClient();

        public HeadHunterUniversitiesHttpClient HeadHunterUniversities => new HeadHunterUniversitiesHttpClient();

        public HeadHunterVacanciesHttpClient HeadHunterVacancies => new HeadHunterVacanciesHttpClient();

        public ImportAreasHttpClient ImportAreas => new ImportAreasHttpClient();

        public ImportBillingTypesHttpClient ImportBillingTypes => new ImportBillingTypesHttpClient();

        public ImportCurrenciesHttpClient ImportCurrencies => new ImportCurrenciesHttpClient();

        public ImportDepartmentsHttpClient ImportDepartments => new ImportDepartmentsHttpClient();

        public ImportDriverLicenseTypesHttpClient ImportDriverLicenseTypes => new ImportDriverLicenseTypesHttpClient();

        public ImportEmployersHttpClient ImportEmployers => new ImportEmployersHttpClient();

        public ImportEmploymentsHttpClient ImportEmployments => new ImportEmploymentsHttpClient();

        public ImportExperiencesHttpClient ImportExperiences => new ImportExperiencesHttpClient();

        public ImportIndustriesHttpClient ImportIndustries => new ImportIndustriesHttpClient();

        public ImportKeySkillsHttpClient ImportKeySkills => new ImportKeySkillsHttpClient();

        public ImportLanguagesHttpClient ImportLanguages => new ImportLanguagesHttpClient();

        public ImportMetroLinesHttpClient ImportMetroLines => new ImportMetroLinesHttpClient();

        public ImportMetroStationsHttpClient ImportMetroStations => new ImportMetroStationsHttpClient();

        public ImportProfessionalRolesHttpClient ImportProfessionalRoles => new ImportProfessionalRolesHttpClient();

        public ImportSchedulesHttpClient ImportSchedules => new ImportSchedulesHttpClient();

        public ImportSpecializationsHttpClient ImportSpecializations => new ImportSpecializationsHttpClient();

        public ImportVacanciesHttpClient ImportVacancies => new ImportVacanciesHttpClient();

        public ImportVacancyTypesHttpClient ImportVacancyTypes => new ImportVacancyTypesHttpClient();

        public ImportWorkingDaysHttpClient ImportWorkingDays => new ImportWorkingDaysHttpClient();

        public ImportWorkingTimeIntervalsHttpClient ImportWorkingTimeIntervals => new ImportWorkingTimeIntervalsHttpClient();

        public ImportWorkingTimeModesHttpClient ImportWorkingTimeModes => new ImportWorkingTimeModesHttpClient();

        public VacanciesHttpClient Vacancies => new VacanciesHttpClient();

        public EmployersHttpClient Employers => new EmployersHttpClient();

        public BillingTypesHttpClient BillingTypes => new BillingTypesHttpClient();

        public CurrenciesHttpClient Currencies => new CurrenciesHttpClient();

        public DepartmentsHttpClient Departments => new DepartmentsHttpClient();

        public DriverLicenseTypesHttpClient DriverLicenseTypes => new DriverLicenseTypesHttpClient();

        public EmploymentsHttpClient Employments => new EmploymentsHttpClient();

        public ExperiencesHttpClient Experiences => new ExperiencesHttpClient();

        public IndustriesHttpClient Industries => new IndustriesHttpClient();

        public LanguagesHttpClient Languages => new LanguagesHttpClient();

        public MetroLinesHttpClient MetroLines => new MetroLinesHttpClient();

        public MetroStationsHttpClient MetroStations => new MetroStationsHttpClient();

        public ProfessionalRolesHttpClient ProfessionalRoles => new ProfessionalRolesHttpClient();

        public SchedulesHttpClient Schedules => new SchedulesHttpClient();

        public SpecializationsHttpClient Specializations => new SpecializationsHttpClient();

        public VacancyTypesHttpClient VacancyTypes => new VacancyTypesHttpClient();

        public WorkingDaysHttpClient WorkingDays => new WorkingDaysHttpClient();

        public WorkingTimeIntervalsHttpClient WorkingTimeIntervals => new WorkingTimeIntervalsHttpClient();

        public WorkingTimeModesHttpClient WorkingTimeModes => new WorkingTimeModesHttpClient();

        public SuggestsHttpClient Suggests => new SuggestsHttpClient();
    }
}
