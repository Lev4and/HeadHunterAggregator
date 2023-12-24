using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Commands
{
    public class ImportHeadHunterEmployerCommand : IRequest<bool>
    {
        public EmployerDto Employer { get; }

        public ImportHeadHunterEmployerCommand(EmployerDto employer)
        {
            Employer = employer;
        }

        internal class Validator : AbstractValidator<ImportHeadHunterEmployerCommand>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<ImportHeadHunterEmployerCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public Task<bool> Handle(ImportHeadHunterEmployerCommand request, 
                CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
