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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly BeautySalonContext _context;

        public EmployeeRepository(BeautySalonContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<Employees>> GetAllAsync()
        {
            return _context.Employees;
        }

        public async Task<Employees> GetByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(a => a.Id == id) ?? throw new ArgumentNullException($"Employee with id {id} not found");
        }

        public async Task InsertAsync(Employees entity)
        {
            await _context.Employees.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employees entity)
        {
            var obj = await GetByIdAsync(entity.Id);
            entity.PasswordHash = obj.PasswordHash;
            _context.Entry(obj).State = EntityState.Detached;
            _context.Employees.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Employees.FirstOrDefaultAsync(a => a.Id == id);
            if (entity is null)
                return false;
            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync(); 
            return true;
        }

        public async Task<Employees> GetByEmailAsync(string email)
        {
            return await _context.Employees.FirstOrDefaultAsync(o => o.Email.Equals(email)) ?? throw new ArgumentNullException($"Employee with email {email} not found");
        }
    }
}
