using FluentValidation;

namespace HeadHunter.Database.MongoDb.Features.DriverLicenseType.Find
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(command => command.HeadHunterId).NotEmpty();
        }
    }
}
