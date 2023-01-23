using HeadHunter.Core.Abstracts;
using HeadHunter.EntityFramework.Domain;

namespace HeadHunter.EntityFramework.Abstracts
{
    public interface IEntityFrameworkFactory<TInput, TOutput> : IFactory<TInput, TOutput> 
        where TOutput : EntityFrameworkEntityBase
    {

    }
}
