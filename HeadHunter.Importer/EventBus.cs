using HeadHunter.Models;

namespace HeadHunter.Importer
{
    public class EventBus
    {
        public event Func<Vacancy, Task> OnVacancyImported;

        public Task RaiseOnVacancyImported(Vacancy vacancy) => OnVacancyImported?.Invoke(vacancy) ?? Task.CompletedTask;

        public void Subscribe(Func<Vacancy, Task> handler)
        {
            OnVacancyImported += handler;
        }
    }
}
