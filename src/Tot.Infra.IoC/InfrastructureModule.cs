using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tot.Infra.Bus;
using Tot.Infra.Persistence;
using Tot.Shared;
using Tot.Shared.Repositories;

namespace Tot.Infra.IoC
{
    public static class InfrastructureModule
    {
        public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TotDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFeedbackWriteOnlyRepository, FeedbackWriteOnlyRepository>();
        }
    }
}