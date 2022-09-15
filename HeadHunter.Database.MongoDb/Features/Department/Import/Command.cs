namespace HeadHunter.Database.MongoDb.Features.Department.Import
{
    public class Command : IImportCommand<Models.Department, Collections.Department>
    {
        public Models.Department Model { get; set; }

        public Command()
        {

        }

        public Command(Models.Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }

            Model = department;
        }
    }
}
