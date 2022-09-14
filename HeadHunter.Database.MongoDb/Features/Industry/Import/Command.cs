namespace HeadHunter.Database.MongoDb.Features.Industry.Import
{
    public class Command : IImportCommand<Models.Industry, Collections.Industry>
    {
        public Models.Industry Model { get; set; }

        public Command(Models.Industry industry)
        {
            if (industry == null)
            {
                throw new ArgumentNullException(nameof(industry));
            }

            Model = industry;
        }
    }
}
