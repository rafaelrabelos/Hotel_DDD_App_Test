using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using hotel.infra.ioc;

namespace hotel.presentation.api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            NativeInjector.RegisterServices(services, configuration);
        }
    }
}
