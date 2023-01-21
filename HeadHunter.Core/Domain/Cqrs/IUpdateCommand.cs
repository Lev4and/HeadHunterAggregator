namespace HeadHunter.Core.Domain.Cqrs
{
    public interface IUpdateCommand<TRequest, TResponse> : ICommand<TResponse>
    {
        public TRequest Model { get; }
    }
}
