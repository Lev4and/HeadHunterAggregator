using HeadHunterAggregator.Infrastructure.Web.Http;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter
{
    public class VacanciesHttpClient : HeadHunterHttpClient
    {
        private readonly TimeZoneInfo _moscowTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");

        public VacanciesHttpClient() : base(new Uri(HeadHunterRoutes.VacanciesUriPath, UriKind.Relative))
        {

        }

        public async Task<ResponseModel<PagedResponseModelDto<VacancyDto>>> GetVacanciesAsync(int page, int perPage,
            DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken = default)
        {
            if (page < 1 || page * perPage > 1999) throw new ArgumentOutOfRangeException(nameof(page));
            if (perPage < 1 || perPage > 100) throw new ArgumentOutOfRangeException(nameof(perPage));
            if (dateFrom > dateTo) throw new ArgumentOutOfRangeException(nameof(dateFrom));

            return await GetAsync<PagedResponseModelDto<VacancyDto>>(string.Format("?page={0}&per_page={1}&date_from={2}&" +
                "date_to={3}&order_by={4}", page, perPage, TimeZoneInfo.ConvertTimeFromUtc(dateFrom, _moscowTimeZone)
                    .ToString("yyyy-MM-ddTHH:mm:ss"), TimeZoneInfo.ConvertTimeFromUtc(dateTo, _moscowTimeZone)
                        .ToString("yyyy-MM-ddTHH:mm:ss"), "publication_time"), cancellationToken);
        }

        public async Task<ResponseModel<VacancyDto>> GetVacancyAsync(long id,
            CancellationToken cancellationToken = default)
        {
            if (id < 1) throw new ArgumentOutOfRangeException(nameof(id));

            return await GetAsync<VacancyDto>(string.Format("{0}", id), cancellationToken);
        }
    }
}
