using MediatR;

namespace HeadHunter.Database.MongoDb.Features.MetroStation.GetAll
{
    public class Command : IRequest<List<Collections.MetroStation>>
    {

    }
}
