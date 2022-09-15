namespace HeadHunter.Database.MongoDb.Features.Currency.Import
{
    public class Command : IImportCommand<Models.Currency, Collections.Currency>
    {
        public Models.Currency Model { get; set; }

        public Command()
        {

        }

        public Command(Models.Currency currency)
        {
            if (currency == null)
            {
                throw new ArgumentNullException(nameof(currency));
            }

            Model = currency;
        }
    }
}
