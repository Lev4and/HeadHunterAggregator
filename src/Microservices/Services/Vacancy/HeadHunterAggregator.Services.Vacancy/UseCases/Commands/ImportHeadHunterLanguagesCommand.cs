using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Commands
{
    public class ImportHeadHunterLanguagesCommand : IRequest<bool>
    {
        public IReadOnlyCollection<LanguageDto> Languages { get; }

        public ImportHeadHunterLanguagesCommand(IReadOnlyCollection<LanguageDto> languages)
        {
            Languages = languages;
        }

        internal class Validator : AbstractValidator<ImportHeadHunterLanguagesCommand>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<ImportHeadHunterLanguagesCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public Task<bool> Handle(ImportHeadHunterLanguagesCommand request,
                CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
