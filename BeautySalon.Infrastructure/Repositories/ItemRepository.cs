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
    public class ItemRepository : IItemRepository
    {
        private readonly BeautySalonContext _context;

        public ItemRepository(BeautySalonContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<Items>> GetAllAsync()
        {
            return _context.Items;
        }

        public async Task<Items> GetByIdAsync(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(a => a.Id == id) ?? throw new ArgumentNullException($"Client with id {id} not found");
        }

        public async Task InsertAsync(Items entity)
        {
            await _context.Items.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Items entity)
        {
            _context.Items.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Items.FirstOrDefaultAsync(a => a.Id == id);
            if (entity is null)
                return false;
            _context.Items.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
