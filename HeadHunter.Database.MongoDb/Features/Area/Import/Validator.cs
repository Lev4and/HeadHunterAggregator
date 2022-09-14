using FluentValidation;

namespace HeadHunter.Database.MongoDb.Features.Area.Import
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(command => command.Model).NotNull();
            RuleFor(command => command.Model.Id).NotEmpty();
            RuleFor(command => command.Model.Name).NotEmpty();
        }
    }
}
