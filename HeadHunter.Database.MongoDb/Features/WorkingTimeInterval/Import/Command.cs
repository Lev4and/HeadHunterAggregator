namespace HeadHunter.Database.MongoDb.Features.WorkingTimeInterval.Import
{
    public class Command : IImportCommand<Models.WorkingTimeInterval, Collections.WorkingTimeInterval>
    {
        public Models.WorkingTimeInterval Model { get; set; }

        public Command(Models.WorkingTimeInterval workingTimeInterval)
        {
            if (workingTimeInterval == null)
            {
                throw new ArgumentNullException(nameof(workingTimeInterval));
            }

            Model = workingTimeInterval;
        }
    }
}
