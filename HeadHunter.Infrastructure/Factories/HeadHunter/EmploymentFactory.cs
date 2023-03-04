using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IEmploymentFactory : IFactory<ResponseModels.Employment?, Entities.Employment?>
    {

    }

    internal class EmploymentFactory : IEmploymentFactory
    {
        public Entities.Employment? Create(ResponseModels.Employment? input)
        {
            if (input == null) return null;

            return new Entities.Employment
            {
                HeadHunterId = input.Id, 
                Name = input.Name
            };
        }
    }
}
