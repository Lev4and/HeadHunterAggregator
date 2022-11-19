using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Recent
{
    public class Command : IRequest<List<Collections.Vacancy>>
    {
        public int Limit { get; set; }

        public Command(int limit)
        {
            Limit = limit;
        }
    }
}
