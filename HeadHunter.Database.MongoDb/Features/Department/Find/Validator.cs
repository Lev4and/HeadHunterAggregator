using FluentValidation;

namespace HeadHunter.Database.MongoDb.Features.Department.Find
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(command => command.Name).NotEmpty();
            RuleFor(command => command.HeadHunterId).NotEmpty();
        }
    }
}
