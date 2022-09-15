using MediatR;

namespace HeadHunter.Database.MongoDb.Features.KeySkill.Find
{
    public class Command : IRequest<Collections.KeySkill>
    {
        public string Name { get; set; }

        public Command(string name)
        {
            Name = name;
        }
    }
}
