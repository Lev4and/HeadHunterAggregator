using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.Resource.Import
{
    public interface IEmployersHttpClient
    {
        Task<ResponseModel<bool>> ImportAsync(Employer employer);
    }
}
