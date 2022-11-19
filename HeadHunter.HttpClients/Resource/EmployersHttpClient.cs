using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;
using MongoDB.Bson;

namespace HeadHunter.HttpClients.Resource
{
    public class EmployersHttpClient : ResourceHttpClient
    {
        public EmployersHttpClient() : base(ResourceRoutes.EmployersPath)
        {

        }

        public async Task<ResponseModel<Employer>> GetEmployerByByHeadHunterIdAsync(long id)
        {
            if (id < ResourceConstants.HeadHunterIdLowerValue)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await Get<Employer>($"{id}");
        }

        public async Task<ResponseModel<Employer>> GetEmployerInfoByIdAsync(ObjectId id)
        {
            if (id == ObjectId.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await Get<Employer>($"{id}/info");
        }

        public async Task<ResponseModel<long>> GetCountEmployersAsync()
        {
            return await Get<long>($"{ResourceRoutes.EmployersCountQuery}");
        }
    }
}
