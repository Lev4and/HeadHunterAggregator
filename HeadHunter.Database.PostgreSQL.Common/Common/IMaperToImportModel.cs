namespace HeadHunter.Database.PostgreSQL.Common.Common
{
    public interface IMaperToImportModel<TResponse, TFindModel> : IMaperToFindModel<TFindModel>, IMaperToSaveModel<TResponse> where TResponse : class where TFindModel : class
    {

    }
}
