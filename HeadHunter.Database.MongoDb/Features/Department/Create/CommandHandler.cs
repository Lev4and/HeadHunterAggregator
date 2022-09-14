using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.Department.Create
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
            var department = new Collections.Department(request.Department);

            await _repository.AddAsync(department);

            return department;
        }
    }
}
