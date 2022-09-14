using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Address.Create
{
    public class Command : IRequest<Collections.Address>
    {
        public Models.Address Address { get; set; }

        public Command(Models.Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            Address = address;
        }
    }
}
