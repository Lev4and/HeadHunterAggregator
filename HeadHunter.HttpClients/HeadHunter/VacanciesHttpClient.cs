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

        public async Task<ResponseModel<PagedResponseModel<Vacancy>>> GetVacanciesAsync(int page = 1, int perPage = 100)
        {
            if (perPage < 1 || perPage > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(perPage));
            }

            if (page < 1 || page * perPage < 2000)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }

            return await Get<PagedResponseModel<Vacancy>>($"?page={page}&per_page={perPage}");
        }

        public async Task<ResponseModel<Vacancy>> GetVacancyAsync(long id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await Get<Vacancy>($"/{id}");
        }
    }
}
