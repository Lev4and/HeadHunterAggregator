namespace HeadHunter.HttpClients.Resource.Import
{
    public interface IImportHttpContext
    {
        IAreasHttpClient Areas { get; }

        IDictionariesHttpClient Dictionaries { get; }

        IEmployersHttpClient Employers { get; }

        IIndustriesHttpClient Industries { get; }

        ILanguagesHttpClient Languages { get; }

        IMetroHttpClient Metro { get; }

        ISpecializationsHttpClient Specializations { get; }

        IVacanciesHttpClient Vacancies { get; }
    }
}
