using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tot.Infra.IoC
{
    public static class NativeInjector
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterCommand();
            services.RegisterQuery();
            services.RegisterDatabase(configuration);
        }
    }
}