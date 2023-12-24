using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Queries
{
    public class GetHeadHunterIndustriesQuery : IRequest<IReadOnlyCollection<IndustryDto>>
    {
        internal class Handler : IRequestHandler<GetHeadHunterIndustriesQuery, IReadOnlyCollection<IndustryDto>>
        {
            private readonly HeadHunterApi _headHunterApi;

            public Handler(HeadHunterApi headHunterApi)
            {
                _headHunterApi = headHunterApi;
            }

            public async Task<IReadOnlyCollection<IndustryDto>> Handle(GetHeadHunterIndustriesQuery request, 
                CancellationToken cancellationToken)
            {
                var response = await _headHunterApi.Industries.GetIndustriesAsync(cancellationToken);

                return response?.Result ?? throw new NullReferenceException();
            }
        }
    }
}
