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

            var russianTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");

            var moscowDateFrom = TimeZoneInfo.ConvertTimeFromUtc(dateFrom, russianTimeZone);
            var moscowDateTo = TimeZoneInfo.ConvertTimeFromUtc(dateTo, russianTimeZone);

            return await Get<PagedResponseModel<Vacancy>>($"?page={page}&perPage={perPage}" +
                $"&dateFrom={moscowDateFrom.ToString("yyyy-MM-ddTHH:mm:ss")}" +
                $"&dateTo={moscowDateTo.ToString("yyyy-MM-ddTHH:mm:ss")}");
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
