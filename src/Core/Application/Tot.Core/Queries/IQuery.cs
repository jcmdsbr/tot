using MediatR;

namespace Tot.Shared.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
        where TResult : IQueryModel
    {
    }
}