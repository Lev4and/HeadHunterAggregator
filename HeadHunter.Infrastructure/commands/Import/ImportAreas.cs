using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.Core.Extensions;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Infrastructure.Factories.HeadHunter;
using HeadHunter.MongoDB.Abstracts;
using MediatR;

namespace HeadHunter.Infrastructure.Commands.Import
{
    public class ImportAreas : ICommand<bool>
    {
        public Area[] Areas { get; }

        public ImportAreas(Area[] areas)
        {
            if (areas == null) throw new ArgumentNullException(nameof(areas));

            Areas = areas;
        }

        internal class Validator : AbstractValidator<ImportAreas>
        {
            public Validator()
            {
                RuleFor(model => model.Areas).Null().WithMessage($"The {nameof(Areas)} param should be not null.");
            }
        }

        internal class Handler : IRequestHandler<ImportAreas, bool>
        {
            private readonly IAreaFactory _factory;
            private readonly IImportVisitor _visitor;

            public Handler(IAreaFactory factory, IImportVisitor visitor)
            {
                _factory = factory;
                _visitor = visitor;
            }

            public async Task<bool> Handle(ImportAreas request, CancellationToken cancellationToken)
            {
                var areas = _factory.CreateArray(request.Areas);

                return true;
            }
        }
    }
}
