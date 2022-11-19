using FluentValidation;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Recent
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(command => command.Limit).GreaterThan(0);
        }
    }
}
