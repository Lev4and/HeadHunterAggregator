using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Employment.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Models.Employment Employment { get; }

        public Command(Models.Employment employment)
        {
            if (employment == null)
            {
                throw new ArgumentNullException(nameof(employment));
            }

            Employment = employment;
        }
    }
}
