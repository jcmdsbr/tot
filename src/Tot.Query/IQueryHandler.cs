using MediatR;
using Tot.Shared.Queries;

namespace Tot.Query
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult : IQueryModel
    {
    }
}