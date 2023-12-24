namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter
{
    public class HeadHunterApi
    {
        public AreasHttpClient Areas { get; } = new AreasHttpClient();

        public DictionariesHttpClient Dictionaries { get; } = new DictionariesHttpClient();

        public EmployersHttpClient Employers { get; } = new EmployersHttpClient();

        public IndustriesHttpClient Industries { get; } = new IndustriesHttpClient();

        public LanguagesHttpClient Languages { get; } = new LanguagesHttpClient();

        public MetroHttpClient Metro { get; } = new MetroHttpClient();

        public SpecializationsHttpClient Specializations { get; } = new SpecializationsHttpClient();

        public VacanciesHttpClient Vacancies { get; } = new VacanciesHttpClient();
    }
}
