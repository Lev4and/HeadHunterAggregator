using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Features.Employer.Create.Builders;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Employer.Create
{
    public class CommandHandler : IRequestHandler<Command, Collections.Employer>
    {
        private readonly IMediator _mediator;
        private readonly Repository _repository;

        public CommandHandler(IMediator mediator, Repository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<Collections.Employer> Handle(Command request, CancellationToken cancellationToken)
        {
            var employer = await new EmployerBuilder(_mediator, request.Employer)
                .WithArea()
                .WithIndustries()
                .BuildAsync();

            await _repository.AddAsync(employer);

            return employer;
        }
    }
}
