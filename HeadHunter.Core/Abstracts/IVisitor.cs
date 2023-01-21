namespace HeadHunter.Core.Abstracts
{
    public interface IVisitor<TInput> where TInput : class
    {
        void Visit(TInput obj);
    }

    public interface IVisitor<TInput, TOutput> where TInput : class where TOutput : class
    {
        TOutput Visit(TInput obj);
    }

    public interface IAsyncIVisitor<TInput> where TInput : class
    {
        Task Visit(TInput obj);
    }

    public interface IAsyncIVisitor<TInput, TOutput> where TInput : class where TOutput : class
    {
        Task<TOutput> Visit(TInput obj);
    }
}
