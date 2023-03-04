using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IBillingTypeFactory : IFactory<ResponseModels.BillingType?, Entities.BillingType?>
    {

    }

    internal class BillingTypeFactory : IBillingTypeFactory
    {
        public Entities.BillingType? Create(ResponseModels.BillingType? input)
        {
            if (input == null) return null;

            return new Entities.BillingType
            {
                HeadHunterId = input.Id, 
                Name = input.Name
            };
        }
    }
}
