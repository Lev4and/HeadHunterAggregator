using HeadHunter.Core.Abstracts;

namespace HeadHunter.Core.Extensions
{
    public static class FactoryExtensions
    {
        public static TOutput[]? CreateArray<TInput, TOutput>(this IFactory<TInput, TOutput> factory, 
            TInput[]? items)
        {
            if (items == null) return null;

            return items.ToList().Select(factory.Create).ToArray();
        }
    }
}
