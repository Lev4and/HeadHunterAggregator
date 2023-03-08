using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.Core.Extensions;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Infrastructure.Factories.HeadHunter;
using HeadHunter.MongoDB.Abstracts;
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
            private readonly IImportVisitor _visitor;
            private readonly ISpecializationFactory _factory;

            public Handler(IImportVisitor visitor, ISpecializationFactory factory)
            {
                _visitor = visitor;
                _factory = factory;
            }

            public async Task<bool> Handle(ImportSpecializations request, CancellationToken cancellationToken)
            {
                var specializations = _factory.CreateArray(request.Specializations);

                await Task.WhenAll(specializations.Select(specialization =>
                    specialization.Accept(_visitor)));

                return true;
            }
        }
    }
}
