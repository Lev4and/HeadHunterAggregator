using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Vacancy.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportVacanciesHttpClient : ResourceHttpClient, IImporter<Vacancy, Models.Vacancy>
    {
        public ImportVacanciesHttpClient() : base(ResourceRoutes.ImportVacanciesPath)
        {

        }

        public async Task<ResponseModel<Vacancy>> ImportAsync(Models.Vacancy model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<Vacancy>("", new Command(model));
        }
    }
}
