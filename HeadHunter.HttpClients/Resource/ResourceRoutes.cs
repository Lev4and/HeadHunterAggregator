namespace HeadHunter.HttpClients.Resource
{
    public class ResourceRoutes
    {
        public const string Protocol = "http";

        public const string Domain = "lev4and.ru/resource";

        public const string HeadHunterApiPath = "api";

        public const string HeadHunterAreaPath = $"{HeadHunterApiPath}/headHunter";

        public const string HeadHunterVacanciesPath = $"{HeadHunterAreaPath}/vacancies/";

        public const string HeadHunterVacanciesPageQueryParam = "page";

        public const string HeadHunterVacanciesPerPageQueryParam = "perPage";

        public const string HeadHunterVacanciesDateFromQueryParam = "dateFrom";

        public const string HeadHunterVacanciesDateToQueryParam = "dateTo";

        public const string HeadHunterCompaniesPath = $"{HeadHunterAreaPath}/companies/";

        public const string HeadHunterAreasPath = $"{HeadHunterAreaPath}/areas/";

        public const string HeadHunterAreasAllQuery = "all";

        public const string HeadHunterCountriesPath = $"{HeadHunterAreaPath}/countries/";

        public const string HeadHunterCountriesAllQuery = "all";

        public const string HeadHunterSpecializationsPath = $"{HeadHunterAreaPath}/specializations/";

        public const string HeadHunterSpecializationsAllQuery = "all";

        public const string HeadHunterMetroPath = $"{HeadHunterAreaPath}/metro/";

        public const string HeadHunterMetroAllQuery = "all";

        public const string HeadHunterMetroAllStationsCityIdQueryParam = "cityId";

        public const string HeadHunterLanguagesPath = $"{HeadHunterAreaPath}/languages/";

        public const string HeadHunterLanguagesAllQuery = "all";

        public const string HeadHunterIndustriesPath = $"{HeadHunterAreaPath}/industries/";

        public const string HeadHunterIndustriesAllQuery = "all";

        public const string HeadHunterUniversitiesPath = $"{HeadHunterAreaPath}/universities/";

        public const string HeadHunterUniversitiesIdQueryParam = "id";

        public const string HeadHunterUniversitiesUniversityIdQueryParam = "universityId";

        public const string HeadHunterUniversitiesFacultiesQuery = "faculties";

        public const string HeadHunterKeySkillsPath = $"{HeadHunterAreaPath}/keySkills/";

        public const string HeadHunterKeySkillsIdQueryParam = "id";

        public const string HeadHunterDictionariesPath = $"{HeadHunterAreaPath}/dictionaries/";

        public const string HeadHunterSuggestsPath = $"{HeadHunterAreaPath}/suggests/";

        public const string HeadHunterSuggestsAreasQuery = "areas";

        public const string HeadHunterSuggestsCompaniesQuery = "companies";

        public const string HeadHunterSuggestsUniversitiesQuery = "universities";

        public const string HeadHunterSuggestsSpecializationsQuery = "specializations";

        public const string HeadHunterSuggestsProfessionalRolesQuery = "professionalRoles";

        public const string HeadHunterSuggestsKeySkillsQuery = "keySkills";

        public const string HeadHunterSuggestsVacancyPositionsQuery = "vacancyPositions";

        public const string HeadHunterSuggestsVacancyKeyWordsQuery = "vacancyKeyWords";

        public const string HeadHunterSuggestsSearchStringQueryParam = "q";

        public const string ImportAreaPath = $"{HeadHunterApiPath}/import";

        public const string ImportAreasPath = $"{ImportAreaPath}/areas/";

        public const string ImportBillingTypesPath = $"{ImportAreaPath}/billingTypes/";

        public const string ImportCurrenciesPath = $"{ImportAreaPath}/currencies/";

        public const string ImportDepartmentsPath = $"{ImportAreaPath}/departments/";

        public const string ImportDriverLicenseTypesPath = $"{ImportAreaPath}/driverLicenseTypes/";

        public const string ImportEmployersPath = $"{ImportAreaPath}/employers/";

        public const string ImportEmploymentsPath = $"{ImportAreaPath}/employments/";

        public const string ImportExperiencesPath = $"{ImportAreaPath}/experiences/";

        public const string ImportIndustriesPath = $"{ImportAreaPath}/industries/";

        public const string ImportKeySkillsPath = $"{ImportAreaPath}/keySkills/";

        public const string ImportLanguagesPath = $"{ImportAreaPath}/languages/";

        public const string ImportMetroLinesPath = $"{ImportAreaPath}/metroLines/";

        public const string ImportMetroStationsPath = $"{ImportAreaPath}/metroStations/";

        public const string ImportProfessionalRolesPath = $"{ImportAreaPath}/professionalRoles/";

        public const string ImportSchedulesPath = $"{ImportAreaPath}/schedules/";

        public const string ImportSpecializationsPath = $"{ImportAreaPath}/specializations/";

        public const string ImportVacanciesPath = $"{ImportAreaPath}/vacancies/";

        public const string ImportVacancyTypesPath = $"{ImportAreaPath}/vacancyTypes/";

        public const string ImportWorkingDaysPath = $"{ImportAreaPath}/workingDays/";

        public const string ImportWorkingTimeIntervalsPath = $"{ImportAreaPath}/workingTimeIntervals/";

        public const string ImportWorkingTimeModesPath = $"{ImportAreaPath}/workingTimeModes/";

        public const string DefaultAreaPath = $"{HeadHunterApiPath}";

        public const string VacanciesPath = $"{DefaultAreaPath}/vacancies/";

        public const string EmployersPath = $"{DefaultAreaPath}/employers/";

        public const string BillingTypesPath = $"{DefaultAreaPath}/billingTypes/";

        public const string BillingTypesAllQuery = "all";

        public const string CurrenciesPath = $"{DefaultAreaPath}/currencies/";

        public const string CurrenciesAllQuery = "all";

        public const string DepartmentsPath = $"{DefaultAreaPath}/departments/";

        public const string DepartmentsAllQuery = "all";

        public const string DriverLicenseTypesPath = $"{DefaultAreaPath}/driverLicenseType/";

        public const string DriverLicenseTypesAllQuery = "all";

        public const string EmploymentsPath = $"{DefaultAreaPath}/employments/";

        public const string EmploymentsAllQuery = "all";

        public const string ExperiencesPath = $"{DefaultAreaPath}/experiences/";

        public const string ExperiencesAllQuery = "all";

        public const string IndustriesPath = $"{DefaultAreaPath}/industries/";

        public const string IndustriesAllQuery = "all";

        public const string LanguagesPath = $"{DefaultAreaPath}/languages/";

        public const string LanguagesAllQuery = "all";

        public const string MetroLinesPath = $"{DefaultAreaPath}/metroLines/";

        public const string MetroLinesAllQuery = "all";

        public const string MetroStationsPath = $"{DefaultAreaPath}/metroStations/";

        public const string MetroStationsAllQuery = "all";

        public const string ProfessionalRolesPath = $"{DefaultAreaPath}/professionalRoles/";

        public const string ProfessionalRolesAllQuery = "all";

        public const string SchedulesPath = $"{DefaultAreaPath}/schedules/";

        public const string SchedulesAllQuery = "all";

        public const string SpecializationsPath = $"{DefaultAreaPath}/specializations/";

        public const string SpecializationsAllQuery = "all";

        public const string VacancyTypesPath = $"{DefaultAreaPath}/vacancyTypes/";

        public const string VacancyTypesAllQuery = "all";

        public const string WorkingDaysPath = $"{DefaultAreaPath}/workingDays/";

        public const string WorkingDaysAllQuery = "all";

        public const string WorkingTimeIntervalsPath = $"{DefaultAreaPath}/workingTimeIntervals/";

        public const string WorkingTimeIntervalsAllQuery = "all";

        public const string WorkingTimeModesPath = $"{DefaultAreaPath}/workingTimeModes/";

        public const string WorkingTimeModesAllQuery = "all";

        public const string SuggestsPath = $"{DefaultAreaPath}/suggests/";

        public const string SuggestsMainQuery = "main";
    }
}
