namespace HeadHunter.Database.PostgreSQL.Common.Common
{
    public interface IMaperToFindModel<TResponse> : IMaper where TResponse : class
    {
        TResponse MapToFindModel();
    }
}
