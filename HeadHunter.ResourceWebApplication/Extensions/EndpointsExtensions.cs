namespace HeadHunter.ResourceWebApplication.Extensions
{
    public static class EndpointsExtensions
    {
        public static void MapRoutes(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapDefaultRoute();
            endpoint.MapImportAreaRoute();
            endpoint.MapHeadHunterAreaRoute();
        }

        private static void MapDefaultRoute(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapControllerRoute("default", "api/{controller=Home}/{action=Index}/{id?}");
        }

        private static void MapImportAreaRoute(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapAreaControllerRoute("importArea", "Import",
                "api/import/{controller=Home}/{action=Index}/{id?}");
        }

        private static void MapHeadHunterAreaRoute(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapAreaControllerRoute("headHunterArea", "HeadHunter", 
                "api/headhunter/{controller=Home}/{action=Index}/{id?}");
        }
    }
}
