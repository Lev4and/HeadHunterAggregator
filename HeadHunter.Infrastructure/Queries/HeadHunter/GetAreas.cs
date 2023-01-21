using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.HttpClients;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using MediatR;

namespace HeadHunter.Infrastructure.Queries.HeadHunter
{
    public class GetAreas : IQuery<Area[]?>
    {
        public GetAreas()
        {

        }

        internal class Validator : AbstractValidator<GetAreas>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<GetAreas, Area[]?>
        {
            private readonly IHttpContext _context;

            public Handler(IHttpContext context)
            {
                _context = context;
            }

            public async Task<Area[]?> Handle(GetAreas request, CancellationToken cancellationToken)
            {
                var response = await _context.HeadHunter.Areas.GetAreasAsync();

                return response.Result;
            }
        }
    }
}
