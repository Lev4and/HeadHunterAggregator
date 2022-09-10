using FluentValidation;

namespace HeadHunter.Database.MongoDb.Features.KeySkill.Find
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(command => command.Name).NotEmpty();
        }
    }
}
