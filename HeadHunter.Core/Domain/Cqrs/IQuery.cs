using MediatR;

namespace HeadHunter.Core.Domain.Cqrs
{
    public interface IQuery<T> : IRequest<T>
    {

    }
}
