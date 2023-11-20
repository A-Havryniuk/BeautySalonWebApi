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
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly BeautySalonContext _context;

        public AppointmentRepository(BeautySalonContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Appointments>> GetAllAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointments> GetByIdAsync(int id)
        {
            return await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id) ?? throw new ArgumentNullException($"Client with id {id} not found");
        }

        public async Task InsertAsync(Appointments entity)
        {
            await _context.Appointments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Appointments entity)
        {
            _context.Appointments.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
            if (entity is null)
                return false;
            _context.Appointments.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Appointments>> GetByClientId(int id)
        {
            return await _context.Appointments.Where(a => a.ClientId == id).ToListAsync();
        }

        public async Task<IEnumerable<Appointments>> GetByEmployeeId(int id)
        {
            return await _context.Appointments.Where(a => a.EmployeeId == id).ToListAsync();
        }
    }
}
