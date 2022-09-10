using FluentValidation;

namespace HeadHunter.Database.MongoDb.Features.Currency.Find
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(command => command.HeadHunterId).NotEmpty();
        }
    }
}
