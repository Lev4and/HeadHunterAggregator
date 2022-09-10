using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Specialization.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.Specialization Specialization { get; }

        public Command(Collections.Specialization specialization)
        {
            if (specialization == null)
            {
                throw new ArgumentNullException(nameof(specialization));
            }

            Specialization = specialization;
        }
    }
}
