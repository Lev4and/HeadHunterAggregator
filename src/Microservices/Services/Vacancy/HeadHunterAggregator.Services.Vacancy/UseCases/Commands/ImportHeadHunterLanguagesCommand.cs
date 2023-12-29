using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            private readonly ILanguageRepository _repository;

            public Handler(IUnitOfWork unitOfWork, ILanguageRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
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
                            await _repository.FindOneByHeadHunterIdOrAddAsync(
                                new Language { HeadHunterId = language.Id, Name = language.Name }, language.Id, 
                                    cancellationToken);
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
