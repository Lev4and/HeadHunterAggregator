using FluentValidation;

namespace HeadHunter.Database.MongoDb.Features.Specialization.Find
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
