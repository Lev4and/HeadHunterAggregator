namespace HeadHunter.Database.MongoDb.Features.VacancyType.Import
{
    public class Command : IImportCommand<Models.VacancyType, Collections.VacancyType>
    {
        public Models.VacancyType Model { get; set; }

        public Command(Models.VacancyType vacancyType)
        {
            if (vacancyType == null)
            {
                throw new ArgumentNullException(nameof(vacancyType));
            }

            Model = vacancyType;
        }
    }
}
