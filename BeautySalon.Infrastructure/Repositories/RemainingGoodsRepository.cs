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
    public class RemainingGoodsRepository : IRemainingGoods
    {
        private readonly BeautySalonContext _context;

        public RemainingGoodsRepository(BeautySalonContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<RemainingGoods>> GetAllAsync()
        {
            return  _context.RemainingGoods;
        }

        public async Task<RemainingGoods> GetByIdAsync(int id)
        {
            return await _context.RemainingGoods.FirstOrDefaultAsync(a => a.Id == id) ?? throw new ArgumentNullException($"Client with id {id} not found");
        }

        public async Task InsertAsync(RemainingGoods entity)
        {
            await _context.RemainingGoods.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RemainingGoods entity)
        {
            _context.RemainingGoods.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.RemainingGoods.FirstOrDefaultAsync(a => a.Id == id);
            if (entity is null)
                return false;
            _context.RemainingGoods.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
