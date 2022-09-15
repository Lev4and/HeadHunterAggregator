namespace HeadHunter.Database.MongoDb.Features.Schedule.Import
{
    public class Command : IImportCommand<Models.Schedule, Collections.Schedule>
    {
        public Models.Schedule Model { get; set; }

        public Command()
        {

        }

        public Command(Models.Schedule schedule)
        {
            if (schedule == null)
            {
                throw new ArgumentNullException(nameof(schedule));
            }

            Model = schedule;
        }
    }
}
