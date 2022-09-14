using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Specialization.Create
{
    public class Command : IRequest<Collections.Specialization>
    {
        public Models.Specialization Specialization { get; }

        public Command(Models.Specialization specialization)
        {
            if (specialization == null)
            {
                throw new ArgumentNullException(nameof(specialization));
            }

            Specialization = specialization;
        }
    }
}
