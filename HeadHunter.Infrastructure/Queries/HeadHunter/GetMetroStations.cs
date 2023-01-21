using FluentValidation;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.HttpClients;
using MediatR;
using HeadHunter.Core.Domain.Cqrs;

namespace HeadHunter.Infrastructure.Queries.HeadHunter
{
    public class GetMetroStations : IQuery<City[]?>
    {
        public GetMetroStations()
        {

        }

        internal class Validator : AbstractValidator<GetMetroStations>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<GetMetroStations, City[]?>
        {
            private readonly IHttpContext _context;

            public Handler(IHttpContext context)
            {
                _context = context;
            }

            public async Task<City[]?> Handle(GetMetroStations request, CancellationToken cancellationToken)
            {
                var response = await _context.HeadHunter.Metro.GetMetroStationsAsync();

                return response.Result;
            }
        }
    }
}
