using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.Resource.Import
{
    public class DictionariesHttpClient : ImportHttpClient, IDictionariesHttpClient
    {
        public DictionariesHttpClient() : base(ImportRoutes.ImportDictionariesPath)
        {

        }

        public async Task<ResponseModel<bool>> ImportAsync(Dictionaries dictionaries)
        {
            if (dictionaries == null) throw new ArgumentNullException(nameof(dictionaries));

            return await PostAsync<bool>("", dictionaries);
        }
    }
}
