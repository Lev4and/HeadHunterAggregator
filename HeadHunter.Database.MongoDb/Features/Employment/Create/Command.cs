using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Employment.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.Employment Employment { get; }

        public Command(Collections.Employment employment)
        {
            if (employment == null)
            {
                throw new ArgumentNullException(nameof(employment));
            }

            Employment = employment;
        }
    }
}
