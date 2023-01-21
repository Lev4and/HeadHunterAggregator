using FluentValidation;
using HeadHunter.Core.Domain.Cqrs;
using HeadHunter.HttpClients;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using MediatR;

namespace HeadHunter.Infrastructure.Queries.HeadHunter
{
    public class GetIndustries : IQuery<Industry[]?>
    {
        public GetIndustries()
        {

        }

        internal class Validator : AbstractValidator<GetIndustries>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<GetIndustries, Industry[]?>
        {
            private readonly IHttpContext _context;

            public Handler(IHttpContext context)
            {
                _context = context;
            }

            public async Task<Industry[]?> Handle(GetIndustries request, CancellationToken cancellationToken)
            {
                var response = await _context.HeadHunter.Industries.GetIndustriesAsync();

                return response.Result;
            }
        }
    }
}
