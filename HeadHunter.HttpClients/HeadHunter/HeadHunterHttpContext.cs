namespace HeadHunter.HttpClients.HeadHunter
{
    public class HeadHunterHttpContext
    {
        public AreasHttpClient Areas => new AreasHttpClient();

        public DictionariesHttpClient Dictionaries => new DictionariesHttpClient();

        public EmployersHttpClient Employers => new EmployersHttpClient();

        public IndustriesHttpClient Industries => new IndustriesHttpClient();

        public KeySkillsHttpClient KeySkills => new KeySkillsHttpClient();

        public LanguagesHttpClient Languages => new LanguagesHttpClient();

        public MetroHttpClient Metro => new MetroHttpClient();

        public SpecializationsHttpClient Specializations => new SpecializationsHttpClient();

        public SuggestsHttpClient Suggests => new SuggestsHttpClient();

        public UniversitiesHttpClient Universities => new UniversitiesHttpClient();

        public VacanciesHttpClient Vacancies => new VacanciesHttpClient();

        public HeadHunterHttpContext()
        {

        }
    }
}
