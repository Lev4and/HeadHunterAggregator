namespace HeadHunter.HttpClients.Resource.Import
{
    public class ImportHttpContext : IImportHttpContext
    {
        public IAreasHttpClient Areas => new AreasHttpClient();

        public IDictionariesHttpClient Dictionaries => new DictionariesHttpClient();

        public IEmployersHttpClient Employers => new EmployersHttpClient();

        public IIndustriesHttpClient Industries => new IndustriesHttpClient();

        public ILanguagesHttpClient Languages => new LanguagesHttpClient();

        public IMetroHttpClient Metro => new MetroHttpClient();

        public ISpecializationsHttpClient Specializations => new SpecializationsHttpClient();

        public IVacanciesHttpClient Vacancies => new VacanciesHttpClient();
    }
}
