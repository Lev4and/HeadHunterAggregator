namespace HeadHunter.Database.MongoDb.Features.WorkingDay.Import
{
    public class Command : IImportCommand<Models.WorkingDay, Collections.WorkingDay>
    {
        public Models.WorkingDay Model { get; set; }

        public Command()
        {

        }

        public Command(Models.WorkingDay workingDay)
        {
            if (workingDay == null)
            {
                throw new ArgumentNullException(nameof(workingDay));
            }

            Model = workingDay;
        }
    }
}
