namespace HeadHunter.Database.MongoDb.Features.Experience.Import
{
    public class Command : IImportCommand<Models.Experience, Collections.Experience>
    {
        public Models.Experience Model { get; set; }

        public Command(Models.Experience experience)
        {
            if (experience == null)
            {
                throw new ArgumentNullException(nameof(experience));
            }

            Model = experience;
        }
    }
}
