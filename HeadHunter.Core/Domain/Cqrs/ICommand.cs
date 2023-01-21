using MediatR;

namespace HeadHunter.Core.Domain.Cqrs
{
    public interface ICommand<T> : IRequest<T>
    {

    }
}
