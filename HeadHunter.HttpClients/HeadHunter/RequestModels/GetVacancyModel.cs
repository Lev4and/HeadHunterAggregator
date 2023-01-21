namespace HeadHunter.HttpClients.HeadHunter.RequestModels
{
    public class GetVacancyModel
    {
        public long Id { get; }

        public GetVacancyModel(long id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            Id = id;
        }
    }
}
