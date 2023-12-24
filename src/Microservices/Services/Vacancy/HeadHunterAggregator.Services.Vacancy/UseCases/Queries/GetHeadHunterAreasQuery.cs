using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Queries
{
    public class GetHeadHunterAreasQuery : IRequest<IReadOnlyCollection<AreaDto>>
    {
        internal class Handler : IRequestHandler<GetHeadHunterAreasQuery, IReadOnlyCollection<AreaDto>>
        {
            private readonly HeadHunterApi _headHunterApi;

            public Handler(HeadHunterApi headHunterApi)
            {
                _headHunterApi = headHunterApi;
            }

            public async Task<IReadOnlyCollection<AreaDto>> Handle(GetHeadHunterAreasQuery request, 
                CancellationToken cancellationToken)
            {
                var response = await _headHunterApi.Areas.GetAreasAsync(cancellationToken);

                return response?.Result ?? throw new NullReferenceException();
            }
        }
    }
}
