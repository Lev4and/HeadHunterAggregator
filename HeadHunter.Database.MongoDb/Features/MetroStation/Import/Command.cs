namespace HeadHunter.Database.MongoDb.Features.MetroStation.Import
{
    public class Command : IImportCommand<Models.MetroStation, Collections.MetroStation>
    {
        public Models.MetroStation Model { get; set; }

        public Command(Models.MetroStation metroStation)
        {
            if (metroStation == null)
            {
                throw new ArgumentNullException(nameof(metroStation));
            }

            Model = metroStation;
        }
    }
}
