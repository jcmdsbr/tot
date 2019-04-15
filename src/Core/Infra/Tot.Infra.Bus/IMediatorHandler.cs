using System.Threading.Tasks;
using Tot.Shared.Commands;
using Tot.Shared.Queries;

namespace Tot.Infra.Bus
{
    public interface IMediatorHandler
    {
        Task<T> SendCommand<T>(ICommand<T> command) where T : ICommandResult;
        Task<T> ExecuteQuery<T>(IQuery<T> query) where T : IQueryModel;
    }
}