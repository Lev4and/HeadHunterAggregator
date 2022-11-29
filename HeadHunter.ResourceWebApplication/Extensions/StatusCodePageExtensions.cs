namespace HeadHunter.ResourceWebApplication.Extensions
{
    public static class StatusCodePageExtensions
    {
        private static readonly Dictionary<int, string> _statusCodePages = new Dictionary<int, string>()
        {
            { 400, "/api/error/bagRequest" }
        };

        public static void UseStatusCodePage(this WebApplication application)
        {
            application.UseStatusCodePages(context =>
            {
                context.HttpContext.Response.Redirect(_statusCodePages[context.HttpContext.Response.StatusCode]);

                return Task.CompletedTask;
            });
        }
    }
}
