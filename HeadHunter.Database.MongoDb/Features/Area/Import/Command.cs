namespace HeadHunter.Database.MongoDb.Features.Area.Import
{
    public class Command : IImportCommand<Models.Area, Collections.Area>
    {
        public Models.Area Model { get; set; }

        public Command(Models.Area area)
        {
            if (area == null)
            {
                throw new ArgumentNullException(nameof(area));
            }

            Model = area;
        }
    }
}
