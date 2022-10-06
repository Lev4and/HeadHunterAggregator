using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class EmployersHttpClient : ResourceHttpClient
    {
        public EmployersHttpClient() : base(ResourceRoutes.EmployersPath)
        {

        }

        public async Task<ResponseModel<Employer>> GetCompanyAsync(long id)
        {
            if (id < ResourceConstants.HeadHunterIdLowerValue)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await Get<Employer>($"{id}");
        }
    }
}
