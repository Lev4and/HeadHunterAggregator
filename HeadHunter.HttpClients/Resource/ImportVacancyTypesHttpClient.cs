using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.VacancyType.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportVacancyTypesHttpClient : ResourceHttpClient
    {
        public ImportVacancyTypesHttpClient() : base(ResourceRoutes.ImportVacancyTypesPath)
        {

        }

        public async Task<ResponseModel<VacancyType>> Import(Models.VacancyType vacancyType)
        {
            if (vacancyType == null)
            {
                throw new ArgumentNullException(nameof(vacancyType));
            }

            return await Post<VacancyType>("", new Command(vacancyType));
        }
    }
}
