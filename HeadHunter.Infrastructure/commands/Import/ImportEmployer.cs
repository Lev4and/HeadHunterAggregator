using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using MediatR;

namespace HeadHunter.Infrastructure.Commands.Import
{
    public class ImportEmployer : ICommand<bool>
    {
        public Employer Employer { get; }

        public ImportEmployer(Employer employer)
        {
            if (employer == null) throw new ArgumentNullException(nameof(employer));

            Employer = employer;
        }

        internal class Validator : AbstractValidator<ImportEmployer>
        {
            public Validator()
            {
                RuleFor(model => model.Employer).Null().WithMessage($"The {nameof(Employer)} param should be " +
                    $"not null.");
            }
        }

        internal class Handler : IRequestHandler<ImportEmployer, bool>
        {
            public Handler()
            {

            }

            public async Task<bool> Handle(ImportEmployer request, CancellationToken cancellationToken)
            {
                return true;
            }
        }
    }
}
