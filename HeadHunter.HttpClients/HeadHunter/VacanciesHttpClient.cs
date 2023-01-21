using HeadHunter.Core.Extensions;
using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.RequestModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class VacanciesHttpClient : HeadHunterHttpClient, IVacanciesHttpClient
    {
        public VacanciesHttpClient() : base(HeadHunterRoutes.VacanciesPath)
        {

        }

        public async Task<ResponseModel<PagedResponseModel<Vacancy>>> GetVacanciesAsync(int page, int perPage, 
            DateTime dateFrom, DateTime dateTo)
        {
            if (page < 1 || page * perPage > 1999) throw new ArgumentOutOfRangeException(nameof(page));
            if (perPage < 1 || perPage > 100) throw new ArgumentOutOfRangeException(nameof(perPage));
            if (dateFrom > dateTo) throw new ArgumentOutOfRangeException(nameof(dateFrom));
            if (dateTo < dateFrom) throw new ArgumentOutOfRangeException(nameof(dateTo));

            return await GetAsync<PagedResponseModel<Vacancy>>(HeadHunterRoutes.VacanciesPagedQuery
                .Inject(new GetVacanciesModel(page, perPage, dateFrom, dateTo)));
        }

        public async Task<ResponseModel<Vacancy>> GetVacancyAsync(long id)
        {
            if (id < 1) throw new ArgumentOutOfRangeException(nameof(id));

            return await GetAsync<Vacancy>(HeadHunterRoutes.VacanciesVacancyQuery
                .Inject(new GetVacancyModel(id)));
        }
    }
}
