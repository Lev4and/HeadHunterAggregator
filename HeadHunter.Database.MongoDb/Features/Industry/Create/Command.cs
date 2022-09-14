using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Industry.Create
{
    public class Command : IRequest<Collections.Industry>
    {
        public Models.Industry Industry { get; }

        public Command(Models.Industry industry)
        {
            if (industry == null)
            {
                throw new ArgumentNullException(nameof(industry));
            }

            Industry = industry;
        }
    }
}
