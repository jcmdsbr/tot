using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tot.Command;
using Tot.Shared.Commands;

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