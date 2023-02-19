namespace HeadHunter.MongoDB.Core
{
    public static class MongoConfiguration
    {
        public static string? Host => Environment.GetEnvironmentVariable("MONGODB_SERVER");

        public static string? Port => Environment.GetEnvironmentVariable("MONGODB_PORT");

        public static string? DatabaseName => Environment.GetEnvironmentVariable("MONGODB_DB_NAME");

        public static string? Username => Environment.GetEnvironmentVariable("MONGODB_USER");

        public static string? Password => Environment.GetEnvironmentVariable("MONGODB_PASSWORD");
    }
}
