using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public interface IGetAll<T> where T : class
    {
        Task<ResponseModel<T[]>> GetAllAsync();
    }
}
