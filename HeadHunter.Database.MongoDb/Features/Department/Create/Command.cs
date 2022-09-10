using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Department.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.Department Department { get; }

        public Command(Collections.Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }

            Department = department;
        }
    }
}
