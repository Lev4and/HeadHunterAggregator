using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Commands
{
    public class ImportHeadHunterMetroCommand : IRequest<bool>
    {
        public IReadOnlyCollection<CityDto> Cities { get; }

        public ImportHeadHunterMetroCommand(IReadOnlyCollection<CityDto> cities)
        {
            Cities = cities;
        }

        internal class Validator : AbstractValidator<ImportHeadHunterMetroCommand>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<ImportHeadHunterMetroCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public Task<bool> Handle(ImportHeadHunterMetroCommand request, 
                CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
