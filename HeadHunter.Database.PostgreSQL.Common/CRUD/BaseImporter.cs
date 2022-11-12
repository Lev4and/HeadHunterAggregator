using HeadHunter.Database.PostgreSQL.Common.Common;
using HeadHunter.Database.PostgreSQL.Common.CRUD.Commands;
using HeadHunter.Database.PostgreSQL.Common.CRUD.Queries;

namespace HeadHunter.Database.PostgreSQL.Common.CRUD
{
    public class BaseImporter<TEntity, TModel, TFindModel> where TEntity : class where TModel : IMaperToImportModel<TEntity, TFindModel> where TFindModel : class
    {
        private readonly ISaver<TEntity> _saver;
        private readonly IFinder<TEntity, TFindModel> _finder;

        public BaseImporter(ISaver<TEntity> saver, IFinder<TEntity, TFindModel> finder)
        {
            _saver = saver;
            _finder = finder;
        }

        public async Task<TEntity> ImportAsync(TModel model)
        {
            return (await _finder.FindAsync(model.MapToFindModel())) ?? await _saver.SaveAsync(model.MapToSaveModel());
        }
    }
}
