using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;
using MediatR;

namespace HeadHunterAggregator.Services.Vacancy.UseCases.Queries
{
    public class GetHeadHunterSpecializationsQuery : IRequest<IReadOnlyCollection<SpecializationDto>>
    {
        internal class Handler : IRequestHandler<GetHeadHunterSpecializationsQuery, IReadOnlyCollection<SpecializationDto>>
        {
            private readonly HeadHunterApi _headHunterApi;

            public Handler(HeadHunterApi headHunterApi)
            {
                _headHunterApi = headHunterApi;
            }

            public async Task<IReadOnlyCollection<SpecializationDto>> Handle(GetHeadHunterSpecializationsQuery request, 
                CancellationToken cancellationToken)
            {
                var response = await _headHunterApi.Specializations.GetSpecializationsAsync(cancellationToken);

                return response?.Result ?? throw new NullReferenceException();
            }
        }
    }
}
