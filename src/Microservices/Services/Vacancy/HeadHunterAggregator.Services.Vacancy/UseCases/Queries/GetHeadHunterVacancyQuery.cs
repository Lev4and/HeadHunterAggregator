using FluentValidation;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Queries
{
    public class GetHeadHunterVacancyQuery : IRequest<VacancyDto>
    {
        public long Id { get; }

        public GetHeadHunterVacancyQuery(long id)
        {
            Id = id;
        }

        internal class Validator : AbstractValidator<GetHeadHunterVacancyQuery>
        {
            public Validator()
            {
                
            }
        }

        internal class Handler : IRequestHandler<GetHeadHunterVacancyQuery, VacancyDto>
        {
            private readonly HeadHunterApi _headHunterApi;

            public Handler(HeadHunterApi headHunterApi)
            {
                _headHunterApi = headHunterApi;
            }

            public async Task<VacancyDto> Handle(GetHeadHunterVacancyQuery request, CancellationToken cancellationToken)
            {
                var response = await _headHunterApi.Vacancies.GetVacancyAsync(request.Id, cancellationToken);

                return response?.Result ?? throw new NullReferenceException();
            }
        }
    }
}
