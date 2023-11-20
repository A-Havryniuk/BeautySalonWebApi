using BeautySalon.Infrastructure;

namespace BeautySalon.Application.Repositories;

public interface IAppointmentRepository : IBaseRepository<Appointments>
{
    public Task<IEnumerable<Appointments>> GetByClientId(int id);
    public Task<IEnumerable<Appointments>> GetByEmployeeId(int id);

}