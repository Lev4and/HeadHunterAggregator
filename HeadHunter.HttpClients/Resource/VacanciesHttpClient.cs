using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;
using MongoDB.Bson;

namespace HeadHunter.HttpClients.Resource
{
    public class VacanciesHttpClient : ResourceHttpClient
    {
        public VacanciesHttpClient() : base(ResourceRoutes.VacanciesPath)
        {

        }

        public async Task<ResponseModel<Vacancy>> GetVacancyByIdAsync(ObjectId id)
        {
            if (id == ObjectId.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await Get<Vacancy>($"{id}/info");
        }

        public async Task<ResponseModel<Vacancy>> GetVacancyInfoByHeadHunterIdAsync(long id)
        {
            if (id < ResourceConstants.HeadHunterIdLowerValue)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await Get<Vacancy>($"{id}");
        }

        public async Task<ResponseModel<long>> GetCountVacanciesAsync()
        {
            return await Get<long>($"{ResourceRoutes.VacanciesCountQuery}");
        }

        public async Task<ResponseModel<long>> GetCountActiveVacanciesAsync()
        {
            return await Get<long>($"{ResourceRoutes.VacanciesCountActiveQuery}");
        }

        public async Task<ResponseModel<List<Vacancy>>> GetRecentVacanciesAsync(int limit)
        {
            if (limit <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(limit));
            }

            return await Get<List<Vacancy>>($"{ResourceRoutes.VacanciesRecentQuery}?limit={limit}");
        }
    }
}
