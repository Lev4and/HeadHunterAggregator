using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterVacanciesHttpClient : ResourceHttpClient
    {
        public HeadHunterVacanciesHttpClient() : base(ResourceRoutes.HeadHunterVacanciesPath)
        {

        }

        public async Task<ResponseModel<PagedResponseModel<Vacancy>>> GetVacanciesAsync(int page, int perPage, DateTime dateFrom, DateTime dateTo)
        {
            if (perPage < ResourceConstants.HeadHunterPerPageLowerValue || perPage > ResourceConstants.HeadHunterPerPageUpperValue)
            {
                throw new ArgumentOutOfRangeException(nameof(perPage));
            }

            if (page < ResourceConstants.HeadHunterPageLowerValue || page * perPage > ResourceConstants.HeadHunterOffsetUpperValue)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }

            if (dateFrom > dateTo)
            {
                throw new ArgumentOutOfRangeException(nameof(dateFrom));
            }

            if (dateTo < dateFrom)
            {
                throw new ArgumentOutOfRangeException(nameof(dateTo));
            }

            return await Get<PagedResponseModel<Vacancy>>($"?{ResourceRoutes.HeadHunterVacanciesPageQueryParam}={page}" +
                $"&{ResourceRoutes.HeadHunterVacanciesPerPageQueryParam}={perPage}" +
                $"&{ResourceRoutes.HeadHunterVacanciesDateFromQueryParam}={dateFrom.ToString("yyyy-MM-ddTHH:mm:ss")}" +
                $"&{ResourceRoutes.HeadHunterVacanciesDateToQueryParam}={dateTo.ToString("yyyy-MM-ddTHH:mm:ss")}");
        }

        public async Task<ResponseModel<Vacancy>> GetVacancyAsync(long id)
        {
            if (id < ResourceConstants.HeadHunterIdLowerValue)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await Get<Vacancy>($"{id}");
        }
    }
}
