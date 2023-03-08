using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Infrastructure.Factories.HeadHunter;
using HeadHunter.MongoDB.Abstracts;
using MediatR;

namespace HeadHunter.Infrastructure.Commands.Import
{
    public class ImportVacancy : ICommand<bool>
    {
        public Vacancy Vacancy { get; }

        public ImportVacancy(Vacancy vacancy)
        {
            if (vacancy == null) throw new ArgumentNullException(nameof(vacancy));

            Vacancy = vacancy;
        }

        internal class Validator : AbstractValidator<ImportVacancy>
        {
            public Validator()
            {
                RuleFor(model => model.Vacancy).Null().WithMessage($"The {nameof(Vacancy)} param should be " +
                    $"not null.");
            }
        }

        internal class Handler : IRequestHandler<ImportVacancy, bool>
        {
            private readonly IImportVisitor _visitor;
            private readonly IVacancyFactory _factory;

            public Handler(IImportVisitor visitor, IVacancyFactory factory)
            {
                _visitor = visitor;
                _factory = factory;
            }

            public async Task<bool> Handle(ImportVacancy request, CancellationToken cancellationToken)
            {
                await _factory.Create(request.Vacancy).Accept(_visitor);

                return true;
            }
        }
    }
}
