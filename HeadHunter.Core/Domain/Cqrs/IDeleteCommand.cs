namespace HeadHunter.Core.Domain.Cqrs
{
    public interface IDeleteCommand<TId, TResponse> : ICommand<TResponse>
        where TId : struct
    {
        public TId Id { get; }
    }
}
