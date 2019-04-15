using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tot.Core.Interfaces;
using Tot.Infra.Persistence;

namespace Tot.Query
{
    public class ReadDbContext<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public ReadDbContext(TotDbContext db)
        {
            _dbSet = db.Set<TEntity>();
        }


        public virtual async Task<TEntity> FindById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> List()
        {
            return await _dbSet.ToListAsync();
        }
    }
}