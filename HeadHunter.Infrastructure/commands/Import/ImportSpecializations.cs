using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using MediatR;

namespace HeadHunter.Infrastructure.Commands.Import
{
    public class ImportSpecializations : ICommand<bool>
    {
        public Specialization[]? Specializations { get; }

        public ImportSpecializations(Specialization[]? specializations)
        {
            if (specializations == null) throw new ArgumentNullException(nameof(specializations));

            Specializations = specializations;
        }

        internal class Validator : AbstractValidator<ImportSpecializations>
        {
            public Validator()
            {
                RuleFor(model => model.Specializations).Null().WithMessage($"The {nameof(Specializations)} param should be " +
                    $"not null.");
            }
        }

        internal class Handler : IRequestHandler<ImportSpecializations, bool>
        {
            public Handler()
            {

            }

            public async Task<bool> Handle(ImportSpecializations request, CancellationToken cancellationToken)
            {
                return true;
            }
        }
    }
}
