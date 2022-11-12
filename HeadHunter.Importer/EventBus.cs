using HeadHunter.Models;

namespace HeadHunter.Importer
{
    public class EventBus
    {
        public event Func<long, Task> OnVacancyImported;

        public Task RaiseOnVacancyImported(long vacancyId) => OnVacancyImported?.Invoke(vacancyId) ?? Task.CompletedTask;

        public void Subscribe(Func<long, Task> handler)
        {
            OnVacancyImported += handler;
        }
    }
}
