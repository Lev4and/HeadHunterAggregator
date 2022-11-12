namespace HeadHunter.Database.PostgreSQL.Common.Common
{
    public interface IMaperToSaveModel<TResponse> : IMaper where TResponse : class
    {
        TResponse MapToSaveModel();
    }
}
