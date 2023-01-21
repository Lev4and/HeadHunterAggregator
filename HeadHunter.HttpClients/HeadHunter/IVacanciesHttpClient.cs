using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.HeadHunter
{
    public interface IVacanciesHttpClient
    {
        Task<ResponseModel<PagedResponseModel<Vacancy>>> GetVacanciesAsync(int page, int perPage,
            DateTime dateFrom, DateTime dateTo);

        Task<ResponseModel<Vacancy>> GetVacancyAsync(long id);
    }
}
