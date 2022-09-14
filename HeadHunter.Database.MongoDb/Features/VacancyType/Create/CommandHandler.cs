using HeadHunter.Database.MongoDb.Common;
using MediatR;
using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Features.VacancyType.Create
{
    public class CommandHandler : IRequestHandler<Command, Collections.VacancyType>
    {
        private readonly Repository _repository;

        public CommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Collections.VacancyType> Handle(Command request, CancellationToken cancellationToken)
        {
            var vacancyType = new Collections.VacancyType(request.VacancyType);

            await _repository.AddAsync(vacancyType);

            return vacancyType;
        }
    }
}
