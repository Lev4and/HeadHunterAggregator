using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.Resource.Import
{
    public class EmployersHttpClient : ImportHttpClient, IEmployersHttpClient
    {
        public EmployersHttpClient() : base(ImportRoutes.ImportEmployersPath)
        {

        }

        public async Task<ResponseModel<bool>> ImportAsync(Employer employer)
        {
            if (employer == null) throw new ArgumentNullException(nameof(employer));

            return await PostAsync<bool>("", employer);
        }
    }
}
