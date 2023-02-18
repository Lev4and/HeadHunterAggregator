using HeadHunter.MongoDB.Core;
using Microsoft.Extensions.DependencyInjection;

namespace HeadHunter.MongoDB
{
    public static class Configure
    {
        public static void AddMongoDB(this IServiceCollection services)
        {
            services.AddTransient<IMongoDBRepository, HeadHunterRepository>();
        }
    }
}
