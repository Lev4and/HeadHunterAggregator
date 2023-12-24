using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Commands
{
    public class ImportHeadHunterVacancyCommand : IRequest<bool>
    {
        public VacancyDto Vacancy { get; }

        public ImportHeadHunterVacancyCommand(VacancyDto vacancy)
        {
            Vacancy = vacancy;
        }

        internal class Validator : AbstractValidator<ImportHeadHunterVacancyCommand>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<ImportHeadHunterVacancyCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public Task<bool> Handle(ImportHeadHunterVacancyCommand request, 
                CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
