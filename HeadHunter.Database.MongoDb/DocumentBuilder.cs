using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb
{
    public class DocumentBuilder<T> where T : ICollection
    {
        private Queue<Func<Task>> _queue;

        protected T Document { get; set; }

        protected IMediator Mediator { get; }

        public DocumentBuilder(IMediator mediator)
        {
            _queue = new Queue<Func<Task>>();

            Mediator = mediator;
        }

        public DocumentBuilder(IMediator mediator, T document)
        {
            _queue = new Queue<Func<Task>>();

            Document = document;
            Mediator = mediator;
        }

        public async Task<T> BuildAsync()
        {
            var startTaskExecution = null as Func<Task>;

            while (_queue.TryDequeue(out startTaskExecution))
            {
                await startTaskExecution.Invoke().ConfigureAwait(false);
            }

            return Document;
        }

        protected void Enqueue(Func<Task> func)
        {
            _queue.Enqueue(() => Task.Run(async () => await func()));
        }

        protected async Task<TCollection> ImportAsync<TModel, TCollection>(IImportCommand<TModel, TCollection> command) where TModel : class where TCollection : ICollection
        {
            return await Mediator.Send(command);
        }

        protected async Task<List<TCollection>> ImportItemsAsync<TModel, TCollection>(Func<TModel, IImportCommand<TModel, TCollection>> commandCreateFunc, List<TModel> items) where TModel : class where TCollection : ICollection
        {
            var result = new List<TCollection>();

            foreach (var item in items)
            {
                result.Add(await Mediator.Send(commandCreateFunc(item)));
            }

            return result;
        }
    }
}
