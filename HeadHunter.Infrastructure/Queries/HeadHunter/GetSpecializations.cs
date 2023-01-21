using FluentValidation;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.HttpClients;
using MediatR;
using HeadHunter.Core.Domain.Cqrs;

namespace HeadHunter.Infrastructure.Queries.HeadHunter
{
    public class GetSpecializations : IQuery<Specialization[]?>
    {
        public GetSpecializations()
        {

        }

        internal class Validator : AbstractValidator<GetSpecializations>
        {
            public Validator()
            {

            }
        }

        internal class Handler : IRequestHandler<GetSpecializations, Specialization[]?>
        {
            private readonly IHttpContext _context;

            public Handler(IHttpContext context)
            {
                _context = context;
            }

            public async Task<Specialization[]?> Handle(GetSpecializations request, CancellationToken cancellationToken)
            {
                var response = await _context.HeadHunter.Specializations.GetSpecializationsAsync();

                return response.Result;
            }
        }
    }
}
