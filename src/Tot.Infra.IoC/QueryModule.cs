using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tot.Infra.Persistence;
using Tot.Query;
using Tot.Shared.Queries;
using Tot.Shared.Repositories;

namespace Tot.Infra.IoC
{
    public static class QueryModule
    {
        public static void RegisterQuery(this IServiceCollection services)
        {
            services.AddMediatR(typeof(IQueryModel), typeof(IQueryHandler<,>));

            services.AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>));
        }
    }
}