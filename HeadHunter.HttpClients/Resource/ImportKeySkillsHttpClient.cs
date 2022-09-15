using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.KeySkill.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportKeySkillsHttpClient : ResourceHttpClient
    {
        public ImportKeySkillsHttpClient() : base(ResourceRoutes.ImportKeySkillsPath)
        {

        }

        public async Task<ResponseModel<KeySkill>> Import(Models.KeySkill keySkill)
        {
            if (keySkill == null)
            {
                throw new ArgumentNullException(nameof(keySkill));
            }

            return await Post<KeySkill>("", new Command(keySkill));
        }
    }
}
