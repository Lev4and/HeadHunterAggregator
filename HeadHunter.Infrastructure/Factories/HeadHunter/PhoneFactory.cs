using HeadHunter.Core.Abstracts;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IPhoneFactory : IFactory<ResponseModels.Phone, Entities.Phone>
    {

    }

    internal class PhoneFactory : IPhoneFactory
    {
        public Entities.Phone Create(ResponseModels.Phone input)
        {
            return new Entities.Phone
            {
                City = input.City, 
                Number = input.Number, 
                Country = input.Country, 
                Comment = input.Comment
            };
        }
    }
}
