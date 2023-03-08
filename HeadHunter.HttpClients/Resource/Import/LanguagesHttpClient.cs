using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.Resource.Import
{
    public class LanguagesHttpClient : ImportHttpClient, ILanguagesHttpClient
    {
        public LanguagesHttpClient() : base(ImportRoutes.ImportLanguagesPath)
        {

        }

        public async Task<ResponseModel<bool>> ImportAsync(Language[] languages)
        {
            if (languages == null) throw new ArgumentNullException(nameof(languages));

            return await PostAsync<bool>("", languages);
        }
    }
}
