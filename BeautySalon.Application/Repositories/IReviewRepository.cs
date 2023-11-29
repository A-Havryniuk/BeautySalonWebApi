using BeautySalon.Infrastructure;

namespace BeautySalon.Application.Repositories;

public interface IReviewRepository : IBaseRepository<Reviews>
{
    public Task<IEnumerable<Reviews>> GetByRateAsync(int rate);

}