using MediatR;

namespace HeadHunter.Database.MongoDb.Features.ProfessionalRole.Find
{
    public class Command : IRequest<Collections.ProfessionalRole>
    {
        public string Text { get; set; }

        public string Name { get; set; }

        public string HeadHunterId { get; set; }
    }
}
