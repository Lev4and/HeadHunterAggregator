using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.Core.Extensions;
using HeadHunter.Infrastructure.Factories.HeadHunter;
using HeadHunter.MongoDB.Abstracts;
using MediatR;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Commands.Import
{
    public class ImportAreas : ICommand<bool>
    {
        public ResponseModels.Area[] Areas { get; }

        public ImportAreas(ResponseModels.Area[] areas)
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

                foreach (var area in areas)
                {
                    await area.Accept(_visitor);
                }

                return true;
            }
        }
    }
}
