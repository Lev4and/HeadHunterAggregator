using FluentValidation;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Queries
{
    public class GetHeadHunterEmployerQuery : IRequest<EmployerDto>
    {
        public long Id { get; }

        public GetHeadHunterEmployerQuery(long id)
        {
            Id = id;
        }

        internal class Validator : AbstractValidator<GetHeadHunterEmployerQuery>
        {
            public Validator()
            {
                
            }
        }

        internal class Handler : IRequestHandler<GetHeadHunterEmployerQuery, EmployerDto>
        {
            private readonly HeadHunterApi _headHunterApi;

            public Handler(HeadHunterApi headHunterApi)
            {
                _headHunterApi = headHunterApi;
            }

            public async Task<EmployerDto> Handle(GetHeadHunterEmployerQuery request, CancellationToken cancellationToken)
            {
                var response = await _headHunterApi.Employers.GetEmployerAsync(request.Id, cancellationToken);

                return response?.Result ?? throw new NullReferenceException();
            }
        }
    }
}
