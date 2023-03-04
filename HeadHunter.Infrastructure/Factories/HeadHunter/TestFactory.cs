using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface ITestFactory : IFactory<ResponseModels.Test?, Entities.Test?>
    {

    }

    internal class TestFactory : ITestFactory
    {
        public Entities.Test? Create(ResponseModels.Test? input)
        {
            if (input == null) return null;

            return new Entities.Test
            {
                HeadHunterId = input.Id, 
                Name = input.Name
            };
        }
    }
}
