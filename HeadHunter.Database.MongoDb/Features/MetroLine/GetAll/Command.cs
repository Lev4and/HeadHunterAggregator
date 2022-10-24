using MediatR;

namespace HeadHunter.Database.MongoDb.Features.MetroLine.GetAll
{
    public class Command : IRequest<List<Collections.MetroLine>>
    {

    }
}
