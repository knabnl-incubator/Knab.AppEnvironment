using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Knab.AppEnvironment.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationEnvironment(this IServiceCollection services)
        {
            return services
                .AddSingleton<
                    IApplicationEnvironment, 
                    ApplicationEnvironment>();
        }

        public static IServiceCollection AddApplicationEnvironmentWithConfiguration(this IServiceCollection services)
        {
            return services
                .AddSingleton<
                    IApplicationEnvironment<IConfiguration>, 
                    ApplicationEnvironment<IConfiguration>>();
        }
    }
}
