using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.HeadHunter
{
    public interface IEmployersHttpClient
    {
        Task<ResponseModel<Employer>> GetEmployerAsync(long id);
    }
}
