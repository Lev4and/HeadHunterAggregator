using HeadHunter.MongoDB.Core.Conventions;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;

namespace HeadHunter.MongoDB
{
    internal static class ConfigureDatabase
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            var nameConventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            var guidConventionPack = new ConventionPack { new GuidAsStringRepresentationConvention() };

            ConventionRegistry.Register("camelCase", nameConventionPack, filter => true);
            ConventionRegistry.Register("GUIDs as strings Conventions", guidConventionPack, filter => true);

            var mongoClient = new HeadHunterMongoClient();
            var database = mongoClient.GetHeadHunterDb();

            services.AddSingleton(database);
        }
    }
}
