using MediatR;

namespace HeadHunter.Database.MongoDb.Features.WorkingTimeMode.GetAll
{
    public class Command : IRequest<List<Collections.WorkingTimeMode>>
    {

    }
}
