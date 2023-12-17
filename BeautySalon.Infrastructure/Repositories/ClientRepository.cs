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
    public class ClientRepository : IClientRepository
    {
        private readonly BeautySalonContext _context;

        public ClientRepository(BeautySalonContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Clients>> GetAllAsync()
        {
            return  _context.Clients;
        }

        public async Task<Clients> GetByIdAsync(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(a => a.Id == id) ?? throw new ArgumentNullException($"Client with id {id} not found");
        }

        public async Task InsertAsync(Clients entity)
        {
            await _context.Clients.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Clients entity)
        {
            var obj = await GetByIdAsync(entity.Id);
            entity.PasswordHash = obj.PasswordHash;
            _context.Entry(obj).State = EntityState.Detached;
            _context.Clients.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {

            var entity = await _context.Clients.FirstOrDefaultAsync(a => a.Id == id);
            if (entity is null)
                return false;
            _context.Clients.Remove(entity);
            await _context.SaveChangesAsync(); 
            return true;
        }

        public async Task<Clients> GetByEmailAsync(string email)
        {
            return await _context.Clients.FirstOrDefaultAsync(o => o.Email.Equals(email)) ?? throw new ArgumentNullException($"Client with email {email} not found");
        }
    }
}
