using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class VacanciesHttpClient : HeadHunterHttpClient
    {
        public VacanciesHttpClient(): base(HeadHunterRoutes.VacanciesPath)
        {

        }

        public async Task<ResponseModel<PagedResponseModel<Vacancy>>> GetVacanciesAsync(int page, int perPage, DateTime dateFrom, DateTime dateTo)
        {
            if (perPage < HeadHunterConstants.PerPageLowerValue || perPage > HeadHunterConstants.PerPageUpperValue)
            {
                throw new ArgumentOutOfRangeException(nameof(perPage));
            }

            if (page < HeadHunterConstants.PageLowerValue || page * perPage > HeadHunterConstants.OffsetUpperValue)
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

            var russianTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");

            var moscowDateFrom = TimeZoneInfo.ConvertTimeFromUtc(dateFrom, russianTimeZone);
            var moscowDateTo = TimeZoneInfo.ConvertTimeFromUtc(dateTo, russianTimeZone);

            return await Get<PagedResponseModel<Vacancy>>($"?{HeadHunterRoutes.VacanciesPageQueryParam}={page}" +
                $"&{HeadHunterRoutes.VacanciesPerPageQueryParam}={perPage}" +
                $"&{HeadHunterRoutes.VacanciesDateFromQueryParam}={moscowDateFrom.ToString("yyyy-MM-ddTHH:mm:ss")}" +
                $"&{HeadHunterRoutes.VacanciesDateToQueryParam}={moscowDateTo.ToString("yyyy-MM-ddTHH:mm:ss")}");
        }

        public async Task<ResponseModel<Vacancy>> GetVacancyAsync(long id)
        {
            if (id < HeadHunterConstants.IdLowerValue)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await Get<Vacancy>($"{id}");
        }
    }
}
