using System.Threading.Tasks.Dataflow;

namespace HeadHunter.Importer
{
    public abstract class AbstractActor<T>
    {
        private readonly BufferBlock<T> _mailBox;

        public int QueueCount => _mailBox.Count;

        public abstract int ThreadCount { get; }

        public AbstractActor()
        {
            _mailBox = new BufferBlock<T>();

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

        public abstract Task HandleMessage(T message);

        public abstract Task HandleError(T message, Exception ex);

        public Task SendAsync(T message) => _mailBox.SendAsync(message);

        public void Stop() => _mailBox.TryReceiveAll(out var _);

    }
}
