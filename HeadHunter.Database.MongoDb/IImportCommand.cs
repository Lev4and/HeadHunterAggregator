using HeadHunter.Database.MongoDb.Common;
using MediatR;

namespace HeadHunter.Database.MongoDb
{
    public interface IImportCommand<TModel, TCollection> : IRequest<TCollection> where TCollection : ICollection
    {
        TModel Model { get; set; }
    }
}
