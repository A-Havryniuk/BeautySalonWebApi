using BeautySalon.Infrastructure;

namespace BeautySalon.Application.Repositories;

public interface IReviewRepository
{
    public Task<IEnumerable<Reviews>> GetAllAsync();
    public Task<IEnumerable<Reviews>> GetByRateAsync(int rate);
    public Task InsertAsync(Reviews review);
}