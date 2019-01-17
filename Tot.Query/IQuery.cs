using MediatR;

namespace Tot.Query
{
    public interface IQuery<out TResult> : IRequest<TResult>
        where TResult : IQueryModel
    {
    }
}