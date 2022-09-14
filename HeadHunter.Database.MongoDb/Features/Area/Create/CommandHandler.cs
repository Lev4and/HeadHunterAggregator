using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Features.Area.Create.Builders;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Area.Create
{
    public class CommandHandler : IRequestHandler<Command, Collections.Area>
    {
        private readonly IMediator _mediator;
        private readonly Repository _repository;

        public CommandHandler(IMediator mediator, Repository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<Collections.Area> Handle(Command request, CancellationToken cancellationToken)
        {
            var area = await new AreaBuilder(_mediator, new Collections.Area(request.Area))
                .WithParentId()
                .BuildAsync();

            await _repository.AddAsync(area);

            return area;
        }
    }
}
