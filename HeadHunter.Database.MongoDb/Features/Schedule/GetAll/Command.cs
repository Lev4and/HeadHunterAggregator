using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Schedule.GetAll
{
    public class Command : IRequest<List<Collections.Schedule>>
    {

    }
}
