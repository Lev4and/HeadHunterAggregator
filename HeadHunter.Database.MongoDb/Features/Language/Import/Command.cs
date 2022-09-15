namespace HeadHunter.Database.MongoDb.Features.Language.Import
{
    public class Command : IImportCommand<Models.Language, Collections.Language>
    {
        public Models.Language Model { get; set; }

        public Command()
        {

        }

        public Command(Models.Language language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            Model = language;
        }
    }
}
