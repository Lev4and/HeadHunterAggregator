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
                $"&dateFrom={moscowDateFrom.ToString("yyyy-MM-ddTHH:mm:ssK")}" +
                $"&dateTo={moscowDateTo.ToString("yyyy-MM-ddTHH:mm:ssK")}");
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
