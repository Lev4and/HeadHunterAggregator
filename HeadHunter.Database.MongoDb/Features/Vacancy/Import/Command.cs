using Newtonsoft.Json;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Import
{
    public class Command : IImportCommand<Models.Vacancy, Collections.Vacancy>
    {
        public Models.Vacancy Model { get; set; }

        public Command()
        {

        }

        public Command(Models.Vacancy vacancy)
        {
            if (vacancy == null)
            {
                throw new ArgumentNullException(nameof(vacancy));
            }

            Model = vacancy;
        }
    }
}
