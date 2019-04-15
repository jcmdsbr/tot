using MediatR;

namespace Tot.Shared.Commands
{
    public interface ICommand<out TResult> : IRequest<TResult>
        where TResult : ICommandResult
    {
    }
}