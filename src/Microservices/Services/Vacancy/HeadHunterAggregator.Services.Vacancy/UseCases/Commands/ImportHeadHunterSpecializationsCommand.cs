using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Commands
{
    public class ImportHeadHunterSpecializationsCommand : IRequest<bool>
    {
        public IReadOnlyCollection<SpecializationDto> Specializations { get; }

        public ImportHeadHunterSpecializationsCommand(IReadOnlyCollection<SpecializationDto> specializations)
        {
            Specializations = specializations;
        }

        internal class Validator : AbstractValidator<ImportHeadHunterSpecializationsCommand>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<ImportHeadHunterSpecializationsCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public Task<bool> Handle(ImportHeadHunterSpecializationsCommand request, 
                CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
