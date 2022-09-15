using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Vacancy.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportVacanciesHttpClient : ResourceHttpClient
    {
        public ImportVacanciesHttpClient() : base(ResourceRoutes.ImportVacanciesPath)
        {

        }

        public async Task<ResponseModel<Vacancy>> Import(Models.Vacancy vacancy)
        {
            if (vacancy == null)
            {
                throw new ArgumentNullException(nameof(vacancy));
            }

            return await Post<Vacancy>("", new Command(vacancy));
        }
    }
}
