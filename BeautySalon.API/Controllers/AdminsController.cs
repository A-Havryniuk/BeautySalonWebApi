using BeautySalon.Application.Repositories;
using BeautySalon.Contracts.Dtos;
using BeautySalon.Infrastructure;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminRepository _adminRepo;
        private readonly IMapper _mapper;

        public AdminsController(IAdminRepository adminRepo, IMapper mapper)
        {
            _adminRepo = adminRepo;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetAllAdmins")]
        public async Task<IEnumerable<AdminDTO>> GetAllAsync()
        {
            var list = await _adminRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<AdminDTO>>(list);
        }
        [HttpGet("{id:int}", Name = "GetAdminById")]
        public async Task<AdminDTO> GetByIdAsync(int id)
        {
            var entity = await _adminRepo.GetByIdAsync(id);
            return _mapper.Map<AdminDTO>(entity);
        }
        [HttpGet("{email:alpha}", Name = "GetAdminByEmail")]
        public async Task<AdminDTO> GetByEmailAsync(string email)
        {
            var entity = await _adminRepo.GetByEmailAsync(email);
            return _mapper.Map<AdminDTO>(entity);
        }
        [HttpPost(Name = "AddAdmin")]
        public async Task AddAsync(AdminDTO entity)
        {
            var obj = _mapper.Map<Admins>(entity);
            await _adminRepo.InsertAsync(obj);
        }

        [HttpPut(Name = "UpdateAdmin")]
        public async Task UpdateAsync(AdminDTO admin)
        {
            var entity = _mapper.Map<Admins>(admin);
            await _adminRepo.UpdateAsync(entity);
        }
        [HttpDelete(Name = "DeleteAdmin")]
        public async Task DeleteAsync(int id)
        {
            await _adminRepo.DeleteAsync(id);
        }
    }
}
