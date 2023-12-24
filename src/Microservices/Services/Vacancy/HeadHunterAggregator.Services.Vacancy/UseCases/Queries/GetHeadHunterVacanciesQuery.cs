using FluentValidation;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Queries
{
    public class GetHeadHunterVacanciesQuery : IRequest<PagedResponseModelDto<VacancyDto>>
    {
        public int Page { get; }

        public int PerPage { get; }

        public DateTime DateFrom { get; }

        public DateTime DateTo { get; }

        public GetHeadHunterVacanciesQuery(int page, int perPage, DateTime dateFrom, DateTime dateTo)
        {
            Page = page;
            PerPage = perPage;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        internal class Validator : AbstractValidator<GetHeadHunterVacanciesQuery>
        {
            public Validator()
            {
                
            }
        }

        internal class Handler : IRequestHandler<GetHeadHunterVacanciesQuery, PagedResponseModelDto<VacancyDto>>
        {
            private readonly HeadHunterApi _headHunterApi;

            public Handler(HeadHunterApi headHunterApi)
            {
                _headHunterApi = headHunterApi;
            }

            public async Task<PagedResponseModelDto<VacancyDto>> Handle(GetHeadHunterVacanciesQuery request, 
                CancellationToken cancellationToken)
            {
                var response = await _headHunterApi.Vacancies.GetVacanciesAsync(request.Page, request.PerPage,
                    request.DateFrom, request.DateFrom, cancellationToken);

                return response?.Result ?? throw new NullReferenceException();
            }
        }
    }
}
