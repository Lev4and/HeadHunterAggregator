using FluentValidation;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Vacancy.Info
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(command => command.Id).NotEqual(ObjectId.Empty);
        }
    }
}
