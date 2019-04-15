using System.Threading.Tasks;
using MediatR;
using Tot.Shared.Commands;
using Tot.Shared.Queries;

namespace Tot.Infra.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<T> SendCommand<T>(ICommand<T> command) where T : ICommandResult
        {
            return Publish(command);
        }

        public Task<T> ExecuteQuery<T>(IQuery<T> query) where T : IQueryModel
        {
            return Publish(query);
        }

        private Task<T> Publish<T>(IRequest<T> request)
        {
            return _mediator.Send(request);
        }
    }
}