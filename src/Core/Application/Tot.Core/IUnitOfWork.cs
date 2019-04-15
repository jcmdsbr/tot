using System;
using System.Threading.Tasks;

namespace Tot.Shared
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}