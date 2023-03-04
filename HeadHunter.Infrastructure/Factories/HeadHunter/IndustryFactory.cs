using HeadHunter.Core.Abstracts;
using HeadHunter.Core.Extensions;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IIndustryFactory : IFactory<ResponseModels.Industry?, Entities.Industry?>
    {

    }

    internal class IndustryFactory : IIndustryFactory
    {
        private readonly IIndustryFactory _industryFactory;

        public IndustryFactory()
        {
            _industryFactory = new IndustryFactory();
        }

        public Entities.Industry? Create(ResponseModels.Industry? input)
        {
            if (input == null) return null;

            return new Entities.Industry
            {
                HeadHunterId = input.Id, 
                Name = input.Name,
                Children = _industryFactory.CreateArray(input.Industries?.ToArray())
            };
        }
    }
}
