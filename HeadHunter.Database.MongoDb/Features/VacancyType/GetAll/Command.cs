using MediatR;

namespace HeadHunter.Database.MongoDb.Features.VacancyType.GetAll
{
    public class Command : IRequest<List<Collections.VacancyType>>
    {

    }
}
