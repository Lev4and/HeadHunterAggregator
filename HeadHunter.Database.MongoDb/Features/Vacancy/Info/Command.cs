using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Info
{
    public class Command : IRequest<Collections.Vacancy>
    {
        public ObjectId Id { get; set; }

        public Command(ObjectId id)
        {
            Id = id;
        }
    }
}
