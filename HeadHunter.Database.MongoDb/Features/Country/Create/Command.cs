using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Country.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Models.Country Country { get; }

        public Command(Models.Country country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            Country = country;
        }
    }
}
