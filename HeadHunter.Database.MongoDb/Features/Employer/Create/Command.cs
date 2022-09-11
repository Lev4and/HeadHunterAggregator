using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Employer.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Models.Employer Employer { get; }

        public Command(Models.Employer employer)
        {
            if (employer == null)
            {
                throw new ArgumentNullException(nameof(employer));
            }

            Employer = employer;
        }
    }
}
