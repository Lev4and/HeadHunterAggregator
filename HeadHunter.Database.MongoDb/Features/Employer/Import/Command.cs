namespace HeadHunter.Database.MongoDb.Features.Employer.Import
{
    public class Command : IImportCommand<Models.Employer, Collections.Employer>
    {
        public Models.Employer Model { get; set; }

        public Command()
        {

        }

        public Command(Models.Employer employer)
        {
            if (employer == null)
            {
                throw new ArgumentNullException(nameof(employer));
            }

            Model = employer;
        }
    }
}
