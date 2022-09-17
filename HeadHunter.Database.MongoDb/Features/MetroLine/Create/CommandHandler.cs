using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Features.MetroLine.Create.Builders;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.MetroLine.Create
{
    public class CommandHandler : IRequestHandler<Command, Collections.MetroLine>
    {
        private readonly IMediator _mediator;
        private readonly Repository _repository;

        public CommandHandler(IMediator mediator, Repository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<Collections.MetroLine> Handle(Command request, CancellationToken cancellationToken)
        {
            var metroLine = await new MetroLineBuilder(_mediator, request.MetroLine)
                .WithAreaId()
                .BuildAsync();

            await _repository.AddAsync(metroLine);

            return metroLine;
        }
    }
}
