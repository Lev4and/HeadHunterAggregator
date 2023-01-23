using HeadHunter.Core.Domain;
using HeadHunter.EntityFramework.Abstracts;

namespace HeadHunter.EntityFramework.Domain
{
    public abstract class EntityFrameworkEntityBase : EntityBase
    {
        public abstract Task Accept(IImporterVisitor visitor);
    }
}
