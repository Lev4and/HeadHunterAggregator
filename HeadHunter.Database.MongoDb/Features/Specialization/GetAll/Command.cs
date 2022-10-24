using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Specialization.GetAll
{
    public class Command : IRequest<List<Collections.Specialization>>
    {

    }
}
