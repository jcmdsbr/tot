using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tot.Shared.Models;
using Tot.Shared.Repositories;

namespace Tot.Infra.Persistence
{
    public class FeedbackWriteOnlyRepository : IFeedbackWriteOnlyRepository
    {
        private readonly TotDbContext _writeDbContext;

        public FeedbackWriteOnlyRepository(TotDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }

        public async Task<Feedback> FindAsync(object id)
        {
            return await _writeDbContext.Feedbacks.FindAsync(id);
        }

        public async Task AddAsync(Feedback entity)
        {
            await _writeDbContext.Feedbacks.AddAsync(entity);
        }

        public async Task UpdateAsync(Feedback entity)
        {
            var entry = await _writeDbContext.Feedbacks.AddAsync(entity);
            entry.State = EntityState.Modified;
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await FindAsync(id);
            _writeDbContext.Feedbacks.Remove(entity);
        }
    }
}