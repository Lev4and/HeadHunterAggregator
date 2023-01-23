using HeadHunter.EntityFramework.Core;

namespace HeadHunter.EntityFramework
{
    public class HeadHunterRepository : BaseRepository
    {
        public HeadHunterRepository(HeadHunterDbContext context) : base(context)
        {

        }
    }
}
