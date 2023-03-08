using HeadHunter.Core.Abstracts;
using HeadHunter.Core.Extensions;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface ISpecializationFactory : IFactory<ResponseModels.Specialization?, Entities.Specialization?>
    {

    }

    internal class SpecializationFactory : ISpecializationFactory
    {
        private readonly ISpecializationFactory _specializationFactory;

        public SpecializationFactory()
        {
            _specializationFactory = this;
        }

        public Entities.Specialization? Create(ResponseModels.Specialization? input)
        {
            if (input == null) return null;

            return new Entities.Specialization
            {
                HeadHunterId = input.Id, 
                Name = input.Name,
                Children = _specializationFactory.CreateArray(input.Specializations?.ToArray())
            };
        }
    }
}
