namespace HeadHunter.Database.MongoDb.Features.KeySkill.Import
{
    public class Command : IImportCommand<Models.KeySkill, Collections.KeySkill>
    {
        public Models.KeySkill Model { get; set; }

        public Command()
        {

        }

        public Command(Models.KeySkill keySkill)
        {
            if (keySkill == null)
            {
                throw new ArgumentNullException(nameof(keySkill));
            }

            Model = keySkill;
        }
    }
}
