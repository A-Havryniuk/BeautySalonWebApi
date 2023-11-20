using BeautySalon.Infrastructure;

namespace BeautySalon.Application.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employees>
{
    public Task<Employees> GetByEmailAsync(string email);
}