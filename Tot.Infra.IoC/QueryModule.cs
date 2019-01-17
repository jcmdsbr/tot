using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tot.Query;

namespace Tot.Infra.IoC
{
    public static class QueryModule
    {
        public static void RegisterQuery(this IServiceCollection services)
        {
            services.AddMediatR(typeof(IQueryModel), typeof(IQueryHandler<,>));

            services.AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadDbContext<>));
        }
    }
}