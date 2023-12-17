using BeautySalon.Infrastructure;

namespace BeautySalon.Application.Repositories;

public interface IAppointmentRepository : IBaseRepository<Appointments>
{
    public Task<IEnumerable<Appointments>> GetByClientIdAsync(int id);
    public Task<IEnumerable<Appointments>> GetByEmployeeIdAsync(int id);
    public Task<bool> DeleteByClientIdAsync(int id);

}