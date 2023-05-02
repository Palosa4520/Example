using Microsoft.Extensions.DependencyInjection;
using Service.Interface;
using Service.Service;

namespace Service;
public static class ServiceRegistration
{
    public static void AddServiceLayer(this IServiceCollection services)
    {
        services.AddSingleton<ITestService, TestService>();
        services.AddSingleton<IUserClientService, UserClientService>();
    }
}
