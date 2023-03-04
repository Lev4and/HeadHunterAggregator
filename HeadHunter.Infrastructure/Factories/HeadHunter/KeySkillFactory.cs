using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IKeySkillFactory : IFactory<ResponseModels.KeySkill?, Entities.KeySkill?>
    {

    }

    internal class KeySkillFactory : IKeySkillFactory
    {
        public Entities.KeySkill? Create(ResponseModels.KeySkill? input)
        {
            if (input == null) return null;

            return new Entities.KeySkill
            {
                Name = input.Name
            };
        }
    }
}
