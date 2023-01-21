using HeadHunter.Core.Abstracts;
using System.Threading.Tasks.Dataflow;

namespace HeadHunter.Core.Actor
{
    public abstract class AbstractActor<TMessage> : IActor<TMessage>
    {
        private readonly BufferBlock<TMessage> _mailBox;

        public int QueueCount => _mailBox.Count;

        public abstract int ThreadCount { get; }

        public AbstractActor()
        {
            _mailBox = new BufferBlock<TMessage>();

            var workers = new List<Task>();

            Task.Run(async () =>
            {
                while (true)
                {
                    while (workers.Count < ThreadCount)
                    {
                        workers.Add(Handle());
                    }

                    await Task.WhenAny(workers);

                    workers.RemoveAll(s => s.IsCompleted);
                }
            });
        }

        private async Task Handle()
        {
            var message = await _mailBox.ReceiveAsync();

            try
            {
                await HandleMessage(message);
            }
            catch (Exception ex)
            {
                _ = HandleError(message, ex);
            }
        }

        public abstract Task HandleMessage(TMessage message);

        public abstract Task HandleError(TMessage message, Exception ex);

        public Task SendAsync(TMessage message) => _mailBox.SendAsync(message);

        public void Stop() => _mailBox.TryReceiveAll(out var _);
    }
}
