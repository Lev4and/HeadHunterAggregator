namespace HeadHunter.HttpClients.HeadHunter.RequestModels
{
    public class GetVacanciesModel
    {
        private readonly TimeZoneInfo _moscowTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");

        public int Page { get; }

        public int PerPage { get; }

        public string DateTo { get; }

        public string OrderBy { get; }

        public string DateFrom { get; }

        public GetVacanciesModel(int page, int perPage, DateTime from, DateTime to)
        {
            if (page < 1 || page * perPage > 1999) throw new ArgumentOutOfRangeException(nameof(page));
            if (perPage < 1 || perPage > 100) throw new ArgumentOutOfRangeException(nameof(perPage));
            if (from > to) throw new ArgumentOutOfRangeException(nameof(from));
            if (to < from) throw new ArgumentOutOfRangeException(nameof(to));

            Page = page - 1;
            PerPage = perPage;
            OrderBy = "publication_time";
            DateTo = TimeZoneInfo.ConvertTimeFromUtc(to, _moscowTimeZone).ToString("yyyy-MM-ddTHH:mm:ss");
            DateFrom = TimeZoneInfo.ConvertTimeFromUtc(from, _moscowTimeZone).ToString("yyyy-MM-ddTHH:mm:ss");
        }
    }
}
