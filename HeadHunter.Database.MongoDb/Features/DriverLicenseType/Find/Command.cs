using MediatR;

namespace HeadHunter.Database.MongoDb.Features.DriverLicenseType.Find
{
    public class Command : IRequest<Collections.DriverLicenseType>
    {
        public string HeadHunterId { get; set; }

        public Command(string headHunterId)
        {
            HeadHunterId = headHunterId;
        }
    }
}
