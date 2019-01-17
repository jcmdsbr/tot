using System.Threading.Tasks;
using Tot.Core.Interfaces;

namespace Tot.Infra.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TotDbContext _context;

        public UnitOfWork(TotDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}