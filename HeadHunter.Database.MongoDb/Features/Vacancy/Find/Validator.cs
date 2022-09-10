using FluentValidation;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Find
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(command => command.HeadHunterId).GreaterThan(0);
        }
    }
}
