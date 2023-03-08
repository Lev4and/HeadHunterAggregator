using HeadHunter.MongoDB.Abstracts;
using HeadHunter.MongoDB.Core.Domain;

namespace HeadHunter.MongoDB.Domain
{
    public abstract class HeadHunterEntityBase : MongoDbEntityBase
    {
        public abstract Task Accept(IImportVisitor visitor);
    }
}
