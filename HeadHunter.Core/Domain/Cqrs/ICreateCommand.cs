namespace HeadHunter.Core.Domain.Cqrs
{
    public interface ICreateCommand<TRequest, TResponse> : ICommand<TResponse>
    {
        public TRequest Model { get; }
    }
}
