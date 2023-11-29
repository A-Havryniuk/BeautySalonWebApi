using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.Application.Repositories
{
    public interface IBaseRepository<T>
    {
        public Task<IQueryable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task InsertAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task<bool> DeleteAsync(int id);
    }
}
