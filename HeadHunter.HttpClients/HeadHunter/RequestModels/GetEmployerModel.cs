namespace HeadHunter.HttpClients.HeadHunter.RequestModels
{
    public class GetEmployerModel
    {
        public long Id { get; }

        public GetEmployerModel(long id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            Id = id;
        }
    }
}
