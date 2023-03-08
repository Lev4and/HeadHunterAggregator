using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.Resource.Import
{
    public interface IVacanciesHttpClient
    {
        Task<ResponseModel<bool>> ImportAsync(Vacancy vacancy);
    }
}
