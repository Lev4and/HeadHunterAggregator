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

        public ResourceHttpContext()
        {

        }
    }
}
