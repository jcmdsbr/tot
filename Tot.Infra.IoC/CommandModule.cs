using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tot.Command;

namespace Tot.Infra.IoC
{
    public static class CommandModule
    {
        public static void RegisterCommand(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ICommandResult), typeof(ICommandHandler<,>));
        }
    }
}