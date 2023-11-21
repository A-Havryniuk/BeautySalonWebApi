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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllEmployees")]
        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            var list = await _employeeRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(list);
        }

        [HttpGet("{id:int}", Name="GetEmployeeById")]
        public async Task<EmployeeDTO> GetByIdAsync(int id)
        {
            var entity = await _employeeRepo.GetByIdAsync(id);
            return _mapper.Map<EmployeeDTO>(entity);
        }
        [HttpGet("{email:alpha}", Name = "GetEmployeeByEmail")]
        public async Task<EmployeeDTO> GetByEmailAsync(string email)
        {
            var entity = await _employeeRepo.GetByEmailAsync(email);
            return _mapper.Map<EmployeeDTO>(entity);
        }

        [HttpPost(Name = "AddEmployee")]
        public async Task AddAsync(EmployeeDTO entity)
        {
            var obj = _mapper.Map<Employees>(entity);
            await _employeeRepo.InsertAsync(obj);
        }
        [HttpPut(Name = "UpdateEmployee")]
        public async Task UpdateAsync(EmployeeDTO employee)
        {
            var entity = _mapper.Map<Employees>(employee);
            await _employeeRepo.UpdateAsync(entity);
        }
        [HttpDelete(Name = "DeleteEmployee")]
        public async Task DeleteAsync(int id)
        {
            await _employeeRepo.DeleteAsync(id);
        }

    }
}
