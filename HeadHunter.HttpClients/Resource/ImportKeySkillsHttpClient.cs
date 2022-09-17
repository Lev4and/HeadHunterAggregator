using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.KeySkill.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportKeySkillsHttpClient : ResourceHttpClient, IImporter<KeySkill, Models.KeySkill>
    {
        public ImportKeySkillsHttpClient() : base(ResourceRoutes.ImportKeySkillsPath)
        {

        }

        public async Task<ResponseModel<KeySkill>> ImportAsync(Models.KeySkill model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<KeySkill>("", new Command(model));
        }
    }
}
