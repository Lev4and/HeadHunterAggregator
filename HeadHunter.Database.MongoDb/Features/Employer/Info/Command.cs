using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Employer.Info
{
    public class Command : IRequest<Collections.Employer>
    {
        public ObjectId Id { get; set; }

        public Command(ObjectId id)
        {
            Id = id;
        }
    }
}
