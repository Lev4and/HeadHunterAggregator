using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.Resource.Import
{
    public class VacanciesHttpClient : ImportHttpClient, IVacanciesHttpClient
    {
        public VacanciesHttpClient() : base(ImportRoutes.ImportVacanciesPath)
        {

        }

        public async Task<ResponseModel<bool>> ImportAsync(Vacancy vacancy)
        {
            if (vacancy == null) throw new ArgumentNullException(nameof(vacancy));

            return await PostAsync<bool>("", vacancy);
        }
    }
}
