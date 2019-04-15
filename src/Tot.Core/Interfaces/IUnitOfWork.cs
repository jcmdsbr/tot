using System;
using System.Threading.Tasks;

namespace Tot.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
