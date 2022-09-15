using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Employer.Create
{
    public class Command : IRequest<Collections.Employer>
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
