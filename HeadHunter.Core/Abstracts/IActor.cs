namespace HeadHunter.Core.Abstracts
{
    public interface IActor<TMessage>
    {
        int ThreadCount { get; }

        Task HandleMessage(TMessage message);

        Task HandleError(TMessage message, Exception ex);

        Task SendAsync(TMessage message);

        void Stop();
    }
}
