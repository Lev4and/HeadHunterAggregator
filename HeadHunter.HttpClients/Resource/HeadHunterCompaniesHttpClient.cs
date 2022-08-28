using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterCompaniesHttpClient : ResourceHttpClient
    {
        public HeadHunterCompaniesHttpClient() : base(ResourceRoutes.HeadHunterCompaniesPath)
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
