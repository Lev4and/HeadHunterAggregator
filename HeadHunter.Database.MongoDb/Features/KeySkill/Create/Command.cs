using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.KeySkill.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Collections.KeySkill KeySkill { get; }

        public Command(Collections.KeySkill keySkill)
        {
            if (keySkill == null)
            {
                throw new ArgumentNullException(nameof(keySkill));
            }

            KeySkill = keySkill;
        }
    }
}
