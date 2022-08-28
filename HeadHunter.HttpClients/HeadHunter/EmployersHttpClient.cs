using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class EmployersHttpClient : HeadHunterHttpClient
    {
        public EmployersHttpClient(): base(HeadHunterRoutes.EmployersPath)
        {

        }

        public async Task<ResponseModel<Employer>> GetEmployerAsync(long id)
        {
            if (id < HeadHunterConstants.IdLowerValue)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await Get<Employer>($"{id}");
        }
    }
}
