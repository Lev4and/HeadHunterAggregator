using HeadHunter.Core.Extensions;
using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.RequestModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class EmployersHttpClient : HeadHunterHttpClient, IEmployersHttpClient
    {
        public EmployersHttpClient() : base(HeadHunterRoutes.EmployersPath)
        {

        }

        public async Task<ResponseModel<Employer>> GetEmployerAsync(long id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            return await GetAsync<Employer>(HeadHunterRoutes.EmployersEmployerQuery
                .Inject(new GetEmployerModel(id)));
        }
    }
}
