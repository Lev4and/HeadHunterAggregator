using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.VacancyType.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.VacancyType VacancyType { get; }

        public Command(Collections.VacancyType vacancyType)
        {
            if (vacancyType == null)
            {
                throw new ArgumentNullException(nameof(vacancyType));
            }

            VacancyType = vacancyType;
        }
    }
}
