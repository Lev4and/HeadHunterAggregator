using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.Core.Extensions;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Infrastructure.Factories.HeadHunter;
using HeadHunter.MongoDB.Abstracts;
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
            private readonly IImportVisitor _visitor;
            private readonly IMetroLineFactory _factory;

            public Handler(IImportVisitor visitor, IMetroLineFactory factory)
            {
                _visitor = visitor;
                _factory = factory;
            }

            public async Task<bool> Handle(ImportMetro request, CancellationToken cancellationToken)
            {
                var lines = request.Cities.SelectMany(city => _factory.CreateArray(city.Lines?.ToArray()));

                await Task.WhenAll(lines.Select(line => line.Accept(_visitor)));

                return true;
            }
        }
    }
}
