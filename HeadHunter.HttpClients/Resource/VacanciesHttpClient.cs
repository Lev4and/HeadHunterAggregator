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

        public async Task<ResponseModel<Vacancy>> GetVacancyByHeadHunterIdAsync(long id)
        {
            if (id < ResourceConstants.HeadHunterIdLowerValue)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await Get<Vacancy>($"{id}");
        }
    }
}
