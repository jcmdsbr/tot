using MediatR;

namespace Tot.Command
{
    public interface ICommand<out TResult> : IRequest<TResult>
        where TResult : ICommandResult
    {
    }
}