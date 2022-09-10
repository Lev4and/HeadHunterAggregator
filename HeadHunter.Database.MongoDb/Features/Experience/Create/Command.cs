using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Experience.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.Experience Experience { get; }

        public Command(Collections.Experience experience)
        {
            if (experience == null)
            {
                throw new ArgumentNullException(nameof(experience));
            }

            Experience = experience;
        }
    }
}
