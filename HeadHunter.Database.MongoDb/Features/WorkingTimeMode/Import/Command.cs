namespace HeadHunter.Database.MongoDb.Features.WorkingTimeMode.Import
{
    public class Command : IImportCommand<Models.WorkingTimeMode, Collections.WorkingTimeMode>
    {
        public Models.WorkingTimeMode Model { get; set; }

        public Command()
        {

        }

        public Command(Models.WorkingTimeMode workingTimeMode)
        {
            if (workingTimeMode == null)
            {
                throw new ArgumentNullException(nameof(workingTimeMode));
            }

            Model = workingTimeMode;
        }
    }
}
