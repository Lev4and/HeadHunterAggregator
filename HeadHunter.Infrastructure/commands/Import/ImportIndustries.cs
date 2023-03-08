using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.Core.Extensions;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Infrastructure.Factories.HeadHunter;
using HeadHunter.MongoDB.Abstracts;
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
            private readonly IImportVisitor _visitor;
            private readonly IIndustryFactory _factory;

            public Handler(IImportVisitor visitor, IIndustryFactory factory)
            {
                _visitor = visitor;
                _factory = factory;
            }

            public async Task<bool> Handle(ImportIndustries request, CancellationToken cancellationToken)
            {
                var industries = _factory.CreateArray(request.Industries);

                await Task.WhenAll(industries.Select(industry => industry.Accept(_visitor)));

                return true;
            }
        }
    }
}
