namespace HeadHunter.EntityFramework
{
    public static class PostgresConfiguration
    {
        public static string? Host => Environment.GetEnvironmentVariable("POSTGRES_SERVER");

        public static string? Port => Environment.GetEnvironmentVariable("POSTGRES_PORT");

        public static string? DatabaseName => Environment.GetEnvironmentVariable("POSTGRES_DB_NAME");

        public static string? Username => Environment.GetEnvironmentVariable("POSTGRES_USER");

        public static string? Password => Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
    }
}
