namespace HeadHunter.Database.MongoDb.Features.MetroLine.Import
{
    public class Command : IImportCommand<Models.MetroLine, Collections.MetroLine>
    {
        public Models.MetroLine Model { get; set; }

        public Command()
        {

        }

        public Command(Models.MetroLine metroLine)
        {
            if (metroLine == null)
            {
                throw new ArgumentNullException(nameof(metroLine));
            }

            Model = metroLine;
        }
    }
}
