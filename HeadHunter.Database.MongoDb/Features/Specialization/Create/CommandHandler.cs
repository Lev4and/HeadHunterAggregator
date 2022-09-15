using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Features.Specialization.Create.Builders;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Specialization.Create
{
    public class CommandHandler : IRequestHandler<Command, Collections.Specialization>
    {
        private readonly IMediator _mediator;
        private readonly Repository _repository;

        public CommandHandler(IMediator mediator, Repository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<Collections.Specialization> Handle(Command request, CancellationToken cancellationToken)
        {
            var specialization = await new SpecializationBuilder(_mediator, new Collections.Specialization(request.Specialization))
                .WithParentId()
                .BuildAsync();

            await _repository.AddAsync(specialization);

            return specialization;
        }
    }
}
