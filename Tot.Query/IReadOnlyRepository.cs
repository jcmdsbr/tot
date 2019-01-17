using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tot.Query
{
    public interface IReadOnlyRepository<TEntity>
    {
        Task<TEntity> FindById(object id);
        Task<IReadOnlyCollection<TEntity>> List();
    }
}