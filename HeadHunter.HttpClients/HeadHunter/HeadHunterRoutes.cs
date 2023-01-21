namespace HeadHunter.HttpClients.HeadHunter
{
    public class HeadHunterRoutes
    {
        public const string Protocol = "https";

        public const string Domain = $"api.hh.ru";

        public const string AreasPath = "areas/";

        public const string DictionariesPath = "dictionaries/";

        public const string EmployersPath = "employers/";

        public const string EmployersEmployerQuery = "{Id}";

        public const string IndustriesPath = "industries/";

        public const string LanguagesPath = "languages/";

        public const string MetroPath = "metro/";

        public const string SpecializationsPath = "specializations/";

        public const string VacanciesPath = "vacancies/";

        public const string VacanciesPagedQuery = "?page={Page}&per_page={PerPage}&date_from={DateFrom}&" +
            "date_to={DateTo}&order_by={OrderBy}";

        public const string VacanciesVacancyQuery = "{Id}";
    }
}
