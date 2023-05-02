using Service;

namespace Example.Extentions
{
    public static class StartupExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddServiceLayer();
            services.AddHttpClient();

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        }
    }
}
