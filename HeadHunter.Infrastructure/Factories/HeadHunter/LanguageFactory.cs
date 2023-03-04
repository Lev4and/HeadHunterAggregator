using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface ILanguageFactory : IFactory<ResponseModels.Language?, Entities.Language?>
    {

    }

    internal class LanguageFactory : ILanguageFactory
    {
        public Entities.Language? Create(ResponseModels.Language? input)
        {
            if (input == null) return null;

            return new Entities.Language
            {
                HeadHunterId = input.Id, 
                Name = input.Name
            };
        }
    }
}
