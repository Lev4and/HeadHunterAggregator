namespace HeadHunter.Database.MongoDb.Features.Specialization.Import
{
    public class Command : IImportCommand<Models.Specialization, Collections.Specialization>
    {
        public Models.Specialization Model { get; set; }

        public Command(Models.Specialization specialization)
        {
            if (specialization == null)
            {
                throw new ArgumentNullException(nameof(specialization));
            }

            Model = specialization;
        }
    }
}
