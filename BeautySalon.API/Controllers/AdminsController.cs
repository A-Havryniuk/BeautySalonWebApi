using BeautySalon.Application.Repositories;
using BeautySalon.Application.Service.Interfaces;
using BeautySalon.Contracts.Dtos;
using BeautySalon.Infrastructure;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IHashService _hashService;

        public AdminsController(IAdminRepository adminRepo, IMapper mapper, IHashService hashServ)
        {
            _adminRepo = adminRepo;
            _mapper = mapper;
            _hashService = hashServ;
        }
        [HttpGet(Name = "GetAllAdmins")]
        [Authorize(Roles = "admin")]
        public async Task<IEnumerable<AdminDTO>> GetAllAsync()
        {
            var list = await _adminRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<AdminDTO>>(list);
        }
        [HttpGet("{id:int}", Name = "GetAdminById")]
        [Authorize(Roles = "admin")]
        public async Task<AdminDTO> GetByIdAsync(int id)
        {
            var entity = await _adminRepo.GetByIdAsync(id);
            return _mapper.Map<AdminDTO>(entity);
        }
        [HttpGet("{email:alpha}", Name = "GetAdminByEmail")]
        [Authorize(Roles = "admin")]
        public async Task<AdminDTO> GetByEmailAsync(string email)
        {
            var entity = await _adminRepo.GetByEmailAsync(email);
            return _mapper.Map<AdminDTO>(entity);
        }
        [HttpPost(Name = "AddAdmin")]
        [Authorize(Roles = "admin")]
        public async Task AddAsync(AdminDTO entity)
        {
            var obj = _mapper.Map<Admins>(entity);
            obj.PasswordHash = _hashService.GetHash(entity.Password);
            await _adminRepo.InsertAsync(obj);
        }

        [HttpPut(Name = "UpdateAdmin")]
        [Authorize(Roles = "admin")]
        public async Task UpdateAsync(AdminDTO admin)
        {
            var entity = _mapper.Map<Admins>(admin);
            await _adminRepo.UpdateAsync(entity);
        }
        [HttpDelete(Name = "DeleteAdmin")]
        [Authorize(Roles = "admin")]
        public async Task DeleteAsync(int id)
        {
            await _adminRepo.DeleteAsync(id);
        }
    }
}
