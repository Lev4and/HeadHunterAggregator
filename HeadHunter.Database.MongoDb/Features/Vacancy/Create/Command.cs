using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.Vacancy Vacancy { get; }

        public Command(Collections.Vacancy vacancy)
        {
            if (vacancy == null)
            {
                throw new ArgumentNullException(nameof(vacancy));
            }

            Vacancy = vacancy;
        }
    }
}
