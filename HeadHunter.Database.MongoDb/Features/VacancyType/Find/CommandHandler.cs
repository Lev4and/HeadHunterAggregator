using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb.Features.VacancyType.Find
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
            return await _repository.FirstAsync<Collections.VacancyType>(vacancyType => vacancyType.HeadHunterId == request.HeadHunterId &&
                vacancyType.Name == request.Name);
        }
    }
}
