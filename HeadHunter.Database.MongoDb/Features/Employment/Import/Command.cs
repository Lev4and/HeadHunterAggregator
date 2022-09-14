namespace HeadHunter.Database.MongoDb.Features.Employment.Import
{
    public class Command : IImportCommand<Models.Employment, Collections.Employment>
    {
        public Models.Employment Model { get; set; }

        public Command(Models.Employment employment)
        {
            if (employment == null)
            {
                throw new ArgumentNullException(nameof(employment));
            }

            Model = employment;
        }
    }
}
