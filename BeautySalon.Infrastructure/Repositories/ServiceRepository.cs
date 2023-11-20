using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalon.Application.Repositories;
using BeautySalon.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly BeautySalonContext _context;

        public ServiceRepository(BeautySalonContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Services>> GetAllAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Services> GetByIdAsync(int id)
        {
            return await _context.Services.FirstOrDefaultAsync(a => a.Id == id) ?? throw new ArgumentNullException($"aDMIN with id {id} not found");
        }

        public async Task InsertAsync(Services entity)
        {
            await _context.Services.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Services entity)
        {
            _context.Services.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Services.FirstOrDefaultAsync(a => a.Id == id);
            if (entity is null)
                return false;
            _context.Services.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
