using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Commands
{
    public class ImportHeadHunterIndustriesCommand : IRequest<bool>
    {
        public IReadOnlyCollection<IndustryDto> Industries { get; }

        public ImportHeadHunterIndustriesCommand(IReadOnlyCollection<IndustryDto> industries)
        {
            Industries = industries;   
        }

        internal class Validator : AbstractValidator<ImportHeadHunterIndustriesCommand>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<ImportHeadHunterIndustriesCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public Task<bool> Handle(ImportHeadHunterIndustriesCommand request, 
                CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
