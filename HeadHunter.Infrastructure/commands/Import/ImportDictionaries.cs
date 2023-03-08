using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using MediatR;

namespace HeadHunter.Infrastructure.Commands.Import
{
    public class ImportDictionaries : ICommand<bool>
    {
        public Dictionaries Dictionaries { get; }

        public ImportDictionaries(Dictionaries dictionaries)
        {
            if (dictionaries == null) throw new ArgumentNullException(nameof(dictionaries));

            Dictionaries = dictionaries;
        }

        internal class Validator : AbstractValidator<ImportDictionaries>
        {
            public Validator()
            {
                RuleFor(model => model.Dictionaries).Null().WithMessage($"The {nameof(Dictionaries)} param should be " +
                    $"not null.");
            }
        }

        internal class Handler : IRequestHandler<ImportDictionaries, bool>
        {
            public Handler()
            {

            }

            public async Task<bool> Handle(ImportDictionaries request, CancellationToken cancellationToken)
            {
                return true;
            }
        }
    }
}
