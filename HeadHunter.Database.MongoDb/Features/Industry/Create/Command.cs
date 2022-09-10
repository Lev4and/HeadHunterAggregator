using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Industry.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.Industry Industry { get; }

        public Command(Collections.Industry industry)
        {
            if (industry == null)
            {
                throw new ArgumentNullException(nameof(industry));
            }

            Industry = industry;
        }
    }
}
