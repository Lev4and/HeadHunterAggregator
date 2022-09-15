namespace HeadHunter.Database.MongoDb.Features.ProfessionalRole.Import
{
    public class Command : IImportCommand<Models.ProfessionalRole, Collections.ProfessionalRole>
    {
        public Models.ProfessionalRole Model { get; set; }

        public Command()
        {

        }

        public Command(Models.ProfessionalRole professionalRole)
        {
            if (professionalRole == null)
            {
                throw new ArgumentNullException(nameof(professionalRole));
            }

            Model = professionalRole;
        }
    }
}
