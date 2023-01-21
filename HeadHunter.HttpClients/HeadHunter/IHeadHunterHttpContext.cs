namespace HeadHunter.HttpClients.HeadHunter
{
    public interface IHeadHunterHttpContext
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
