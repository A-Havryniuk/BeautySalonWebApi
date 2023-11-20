using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalon.Infrastructure;

namespace BeautySalon.Application.Repositories
{
    public interface IAdminRepository : IBaseRepository<Admins>
    {
        public Task<Admins> GetByEmail(string email);
    }
}
