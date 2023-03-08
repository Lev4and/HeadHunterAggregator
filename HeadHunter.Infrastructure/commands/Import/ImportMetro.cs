using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.MongoDB.Entities;
using MediatR;

namespace HeadHunter.Infrastructure.Commands.Import
{
    public class ImportMetro : ICommand<bool>
    {
        public City[] Cities { get; }

        public ImportMetro(City[] cities)
        {
            if (cities == null) throw new ArgumentNullException(nameof(cities));

            Cities = cities;
        }

        internal class Validator : AbstractValidator<ImportMetro>
        {
            public Validator()
            {
                RuleFor(model => model.Cities).Null().WithMessage($"The {nameof(Cities)} param should be " +
                    $"not null.");
            }
        }

        internal class Handler : IRequestHandler<ImportMetro, bool>
        {
            public Handler()
            {

            }

            public async Task<bool> Handle(ImportMetro request, CancellationToken cancellationToken)
            {
                return true;
            }
        }
    }
}
