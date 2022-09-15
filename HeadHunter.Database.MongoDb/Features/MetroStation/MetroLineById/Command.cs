using MediatR;

namespace HeadHunter.Database.MongoDb.Features.MetroStation.MetroLineById
{
    public class Command : IRequest<Collections.MetroLine?>
    {
        public string? MetroLineId { get; set; }

        public Command(string? metroLineId)
        {
            MetroLineId = metroLineId;
        }
    }
}
