using MediatR;

namespace HeadHunter.Database.MongoDb.Features.WorkingTimeInterval.GetAll
{
    public class Command : IRequest<List<Collections.WorkingTimeInterval>>
    {

    }
}
