namespace HeadHunter.Database.MongoDb.Features.BillingType.Import
{
    public class Command : IImportCommand<Models.BillingType, Collections.BillingType>
    {
        public Models.BillingType Model { get; set; }

        public Command(Models.BillingType billingType)
        {
            if (billingType == null)
            {
                throw new ArgumentNullException(nameof(billingType));
            }

            Model = billingType;
        }
    }
}
