using FluentValidation;

namespace HeadHunter.Database.MongoDb.Features.Area.Create
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(command => command.Area).NotNull();
            RuleFor(command => command.Area.Name).NotEmpty();
            RuleFor(command => command.Area.HeadHunterId).NotEmpty();
        }
    }
}
