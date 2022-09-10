using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Country.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.Country Country { get; }

        public Command(Collections.Country country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            Country = country;
        }
    }
}
