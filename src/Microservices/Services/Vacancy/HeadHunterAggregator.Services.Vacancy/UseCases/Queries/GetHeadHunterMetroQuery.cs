using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Queries
{
    public class GetHeadHunterMetroQuery : IRequest<IReadOnlyCollection<CityDto>>
    {
        internal class Handler : IRequestHandler<GetHeadHunterMetroQuery, IReadOnlyCollection<CityDto>>
        {
            private readonly HeadHunterApi _headHunterApi;

            public Handler(HeadHunterApi headHunterApi)
            {
                _headHunterApi = headHunterApi;
            }

            public async Task<IReadOnlyCollection<CityDto>> Handle(GetHeadHunterMetroQuery request, 
                CancellationToken cancellationToken)
            {
                var response = await _headHunterApi.Metro.GetMetroStationsAsync(cancellationToken);

                return response?.Result ?? throw new NullReferenceException();
            }
        }
    }
}
