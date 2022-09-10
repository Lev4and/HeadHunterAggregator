using FluentValidation;

namespace HeadHunter.Database.MongoDb.Features.ProfessionalRole.Find
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(command => command.Text).NotEmpty();
            RuleFor(command => command.Name).NotEmpty();
            RuleFor(command => command.HeadHunterId).NotEmpty();
        }
    }
}
