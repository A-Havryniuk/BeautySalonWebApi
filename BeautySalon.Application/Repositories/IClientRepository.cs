using BeautySalon.Infrastructure;

namespace BeautySalon.Application.Repositories;

public interface IClientRepository: IBaseRepository<Clients>
{
    public Task<Clients> GetByEmailAsync(string email);

}