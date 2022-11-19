using MediatR;

namespace HeadHunter.Database.MongoDb.Features.WorkingDay.GetAll
{
    public class Command : IRequest<List<Collections.WorkingDay>>
    {

    }
}
