using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Filter
{
    public class Command : IRequest<List<Collections.Vacancy>>
    {
        public string SearchString { get; set; }

        public int Page { get; set; }

        public int PerPage { get; set; }
    }
}
