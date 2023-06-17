namespace HeadHunter.Core.Extensions
{
    public static class TaskExtensions
    {
        public static async Task AsMultithread(this IEnumerable<Task> tasks)
        {
            await Task.WhenAll(tasks ?? new List<Task>());
        }

        public static async Task AsMultithread<T>(this IEnumerable<Task<T>> tasks)
        {
            await Task.WhenAll(tasks);
        }
    }
}
