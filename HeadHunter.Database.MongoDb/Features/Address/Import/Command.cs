namespace HeadHunter.Database.MongoDb.Features.Address.Import
{
    public class Command : IImportCommand<Models.Address, Collections.Address>
    {
        public Models.Address Model { get; set; }

        public Command()
        {

        }

        public Command(Models.Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            Model = address;
        }
    }
}
