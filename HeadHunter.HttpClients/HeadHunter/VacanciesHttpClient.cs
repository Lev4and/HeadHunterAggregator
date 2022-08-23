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
            if (perPage < 1 || perPage > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(perPage));
            }

            if (page < 1 || page * perPage >= 2000)
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

            var moscowDateFrom = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateFrom, "Russian Standard Time");
            var moscowDateTo = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTo, "Russian Standard Time");

            return await Get<PagedResponseModel<Vacancy>>($"?page={page}&per_page={perPage}" +
                $"&date_from={moscowDateFrom.ToString("yyyy-MM-ddTHH:mm:ss")}" +
                $"&date_fo={moscowDateTo.ToString("yyyy-MM-ddTHH:mm:ss")}");
        }

        public async Task<ResponseModel<Vacancy>> GetVacancyAsync(long id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await Get<Vacancy>($"{id}");
        }
    }
}
