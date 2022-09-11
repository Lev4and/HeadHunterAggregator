using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.KeySkill.Create
{
    public class Command : IRequest<ObjectId>
    {
        public Models.KeySkill KeySkill { get; }

        public Command(Models.KeySkill keySkill)
        {
            if (keySkill == null)
            {
                throw new ArgumentNullException(nameof(keySkill));
            }

            KeySkill = keySkill;
        }
    }
}
