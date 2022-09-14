namespace HeadHunter.Database.MongoDb.Features.Country.Import
{
    public class Command : IImportCommand<Models.Country, Collections.Country>
    {
        public Models.Country Model { get; set; }

        public Command(Models.Country country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            Model = country;
        }
    }
}
