using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.Department.Find
{
    public class CommandHandler : IRequestHandler<Command, Collections.Department>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.Department> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _repository.FirstAsync<Collections.Department>(department => department.HeadHunterId == request.HeadHunterId &&
                department.Name == request.Name);
        }
    }
}
