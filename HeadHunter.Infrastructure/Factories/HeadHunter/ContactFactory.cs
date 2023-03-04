using HeadHunter.Core.Abstracts;
using HeadHunter.Core.Extensions;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IContactFactory : IFactory<ResponseModels.Contacts?, Entities.Contact?>
    {

    }

    internal class ContactFactory : IContactFactory
    {
        private readonly IPhoneFactory _phoneFactory;

        public ContactFactory(IPhoneFactory phoneFactory)
        {
            _phoneFactory = phoneFactory;
        }

        public Entities.Contact? Create(ResponseModels.Contacts? input)
        {
            if (input == null) return null;

            return new Entities.Contact
            {
                Name = input.Name, 
                Email = input.Email, 
                Phones = _phoneFactory.CreateArray(input.Phones?.ToArray())
            };
        }
    }
}
