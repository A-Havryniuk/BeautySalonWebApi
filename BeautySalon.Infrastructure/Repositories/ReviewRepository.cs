using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalon.Application.Repositories;
using BeautySalon.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BeautySalon.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly BeautySalonContext _context;

        public ReviewRepository(BeautySalonContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Reviews>> GetAllAsync()
        {
            return await _context.Reviews.ToListAsync();
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
    }
}
