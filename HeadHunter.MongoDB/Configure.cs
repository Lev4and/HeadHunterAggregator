using HeadHunter.MongoDB.Abstracts;
using HeadHunter.MongoDB.Core;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Services;
using HeadHunter.MongoDB.HostedServices;
using HeadHunter.MongoDB.Visitors;
using Microsoft.Extensions.DependencyInjection;

namespace HeadHunter.MongoDB
{
    public static class Configure
    {
        public static void AddMongoDb(this IServiceCollection services)
        {
            services.AddDatabase();

            services.AddSingleton<IMongoDbRepository, HeadHunterRepository>();
            services.AddSingleton<ICreatorIndexKeys, CreatorIndexKeys>();
            services.AddSingleton<IImportVisitor, ImportVisitor>();

            services.AddHostedService<ConfigureIndexes>();
        }
    }
}
