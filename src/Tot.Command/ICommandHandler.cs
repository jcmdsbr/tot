using MediatR;
using Tot.Shared.Commands;

namespace Tot.Command
{
    public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
        where TResult : ICommandResult
    {
    }
}