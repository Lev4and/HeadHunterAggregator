using MediatR;

namespace HeadHunter.Database.MongoDb.Features.DriverLicenseType.GetAll
{
    public class Command : IRequest<List<Collections.DriverLicenseType>>
    {

    }
}
