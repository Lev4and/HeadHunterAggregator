using HeadHunter.MongoDB.Core;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Services;
using HeadHunter.MongoDB.HostedServices;
using Microsoft.Extensions.DependencyInjection;

namespace HeadHunter.MongoDB
{
    public static class Configure
    {
        public static void AddMongoDb(this IServiceCollection services)
        {
            services.AddDatabase();
            services.AddTransient<IMongoDbRepository, HeadHunterRepository>();
            services.AddTransient<ICreatorIndexKeys, CreatorIndexKeys>();
            services.AddHostedService<ConfigureIndexes>();
        }
    }
}
