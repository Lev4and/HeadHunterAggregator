using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.VacancyType.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportVacancyTypesHttpClient : ResourceHttpClient, IImporter<VacancyType, Models.VacancyType>
    {
        public ImportVacancyTypesHttpClient() : base(ResourceRoutes.ImportVacancyTypesPath)
        {

        }

        public async Task<ResponseModel<VacancyType>> ImportAsync(Models.VacancyType model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<VacancyType>("", new Command(model));
        }
    }
}
