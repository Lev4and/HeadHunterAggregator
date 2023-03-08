using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.Core.Extensions;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Infrastructure.Factories.HeadHunter;
using HeadHunter.MongoDB.Abstracts;
using MediatR;

namespace HeadHunter.Infrastructure.Commands.Import
{
    public class ImportLanguages : ICommand<bool>
    {
        public Language[] Languages { get; }

        public ImportLanguages(Language[] languages)
        {
            if (languages == null) throw new ArgumentNullException(nameof(languages));

            Languages = languages;
        }

        internal class Validator : AbstractValidator<ImportLanguages>
        {
            public Validator()
            {
                RuleFor(model => model.Languages).Null().WithMessage($"The {nameof(Languages)} param should be " +
                    $"not null.");
            }
        }

        internal class Handler : IRequestHandler<ImportLanguages, bool>
        {
            private readonly IImportVisitor _visitor;
            private readonly ILanguageFactory _factory;

            public Handler(IImportVisitor visitor, ILanguageFactory factory)
            {
                _visitor = visitor;
                _factory = factory;
            }

            public async Task<bool> Handle(ImportLanguages request, CancellationToken cancellationToken)
            {
                var languages = _factory.CreateArray(request.Languages);

                await Task.WhenAll(languages.Select(language => language.Accept(_visitor)));

                return true;
            }
        }
    }
}
