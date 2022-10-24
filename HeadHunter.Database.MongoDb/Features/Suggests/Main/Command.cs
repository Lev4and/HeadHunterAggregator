using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Suggests.Main
{
    public class Command : IRequest<List<string>>
    {
        public string SearchString { get; set; }

        public Command(string searchString)
        {
            SearchString = searchString;
        }
    }
}
