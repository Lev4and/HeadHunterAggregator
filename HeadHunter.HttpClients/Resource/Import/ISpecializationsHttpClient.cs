using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.Resource.Import
{
    public interface ISpecializationsHttpClient
    {
        Task<ResponseModel<bool>> ImportAsync(Specialization[] specializations);
    }
}
