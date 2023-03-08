using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using MediatR;

namespace HeadHunter.Infrastructure.Commands.Import
{
    public class ImportIndustries : ICommand<bool>
    {
        public Industry[] Industries { get; }

        public ImportIndustries(Industry[] industries)
        {
            if (industries == null) throw new ArgumentNullException(nameof(industries));

            Industries = industries;
        }

        internal class Validator : AbstractValidator<ImportIndustries>
        {
            public Validator()
            {
                RuleFor(model => model.Industries).Null().WithMessage($"The {nameof(Industries)} param should be " +
                    $"not null.");
            }
        }

        internal class Handler : IRequestHandler<ImportIndustries, bool>
        {
            public Handler()
            {

            }

            public async Task<bool> Handle(ImportIndustries request, CancellationToken cancellationToken)
            {
                return true;
            }
        }
    }
}
