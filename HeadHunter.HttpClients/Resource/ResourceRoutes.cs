namespace HeadHunter.HttpClients.Resource
{
    public class ResourceRoutes
    {
        public const string Protocol = "http";

        public const string Domain = "194-67-67-175.cloudvps.regruhosting.ru/resource";

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
    }
}
