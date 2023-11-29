using BeautySalon.Application.Repositories;
using BeautySalon.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly BeautySalonContext _context;

        public ReviewRepository(BeautySalonContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Reviews.FirstOrDefaultAsync(a => a.Id == id);
            if (entity is null)
                return false;
            _context.Reviews.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Reviews>> GetAllAsync()
        {
            return _context.Reviews;
        }

        public async Task<Reviews> GetByIdAsync(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(a => a.Id == id) ?? throw new ArgumentNullException($"Review with id {id} not found");
        }

        public async Task<IEnumerable<Reviews>> GetByRateAsync(int rate)
        {
            return await _context.Reviews.Where(o => o.Rate == rate).ToListAsync();
        }

        public async Task InsertAsync(Reviews entity)
        {
            await _context.Reviews.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reviews entity)
        {
            _context.Reviews.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
