namespace HeadHunter.Database.MongoDb.Features.DriverLicenseType.Import
{
    public class Command : IImportCommand<Models.DriverLicenseType, Collections.DriverLicenseType>
    {
        public Models.DriverLicenseType Model { get; set; }

        public Command(Models.DriverLicenseType driverLicenseType)
        {
            if (driverLicenseType == null)
            {
                throw new ArgumentNullException(nameof(driverLicenseType));
            }

            Model = driverLicenseType;
        }
    }
}
