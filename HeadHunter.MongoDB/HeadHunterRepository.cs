using HeadHunter.MongoDB.Core;
using MongoDB.Driver;

namespace HeadHunter.MongoDB
{
    public class HeadHunterRepository : BaseRepository
    {
        public HeadHunterRepository(IMongoDatabase database) : base(database)
        {

        }
    }
}
