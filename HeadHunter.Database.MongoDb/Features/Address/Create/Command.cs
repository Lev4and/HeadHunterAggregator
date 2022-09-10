using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Address.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.Address Address { get; set; }

        public Command(Collections.Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            Address = address;
        }
    }
}
