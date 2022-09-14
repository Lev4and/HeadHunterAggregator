using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Features.Industry.Create.Builders;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Industry.Create
{
    public class CommandHandler : IRequestHandler<Command, Collections.Industry>
    {
        private readonly IMediator _mediator;
        private readonly Repository _repository;

        public CommandHandler(IMediator mediator, Repository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<Collections.Industry> Handle(Command request, CancellationToken cancellationToken)
        {
            var industry = await new IndustryBuilder(_mediator, new Collections.Industry(request.Industry))
                .WithParentId()
                .BuildAsync();

            await _repository.AddAsync(industry);

            return industry;
        }
    }
}
