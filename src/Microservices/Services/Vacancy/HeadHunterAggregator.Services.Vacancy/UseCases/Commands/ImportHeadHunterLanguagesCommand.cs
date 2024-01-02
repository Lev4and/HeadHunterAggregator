using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Mappers;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories;
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
            private readonly ILanguageMapper _languageMapper;
            private readonly ILanguageRepository _languageRepository;

            public Handler(IUnitOfWork unitOfWork, ILanguageMapper languageMapper, ILanguageRepository languageRepository)
            {
                _unitOfWork = unitOfWork;
                _languageMapper = languageMapper;
                _languageRepository = languageRepository;
            }

            public async Task<bool> Handle(ImportHeadHunterLanguagesCommand request,
                CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        foreach (var language in request.Languages)
                        {
                            await _languageRepository.FindOneByHeadHunterIdOrAddAsync(_languageMapper.Map(language), 
                                language.Id, cancellationToken);
                        }

                        await _unitOfWork.SaveChangesAsync(cancellationToken);

                        await transaction.CommitAsync(cancellationToken);

                        return true;
                    }
                    catch
                    {
                        await transaction.RollbackAsync(cancellationToken);

                        return false;
                    }
                }
            }
        }
    }
}
