using FluentValidation;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Commands
{
    public class ImportHeadHunterDictionariesCommand : IRequest<bool>
    {
        public DictionariesDto Dictionaries { get; }

        public ImportHeadHunterDictionariesCommand(DictionariesDto dictionaries)
        {
            Dictionaries = dictionaries;
        }

        internal class Validator : AbstractValidator<ImportHeadHunterDictionariesCommand>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<ImportHeadHunterDictionariesCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public Task<bool> Handle(ImportHeadHunterDictionariesCommand request, 
                CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
