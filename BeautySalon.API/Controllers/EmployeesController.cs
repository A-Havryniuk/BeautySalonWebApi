using BeautySalon.Application.Repositories;
using BeautySalon.Application.Service.Interfaces;
using BeautySalon.Contracts.Dtos;
using BeautySalon.Infrastructure;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using Mapster;

namespace BeautySalon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;

        public EmployeesController(IEmployeeRepository employeeRepo, IMapper mapper, IHashService hashService)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
            _hashService = hashService;
        }

        [HttpGet(Name = "GetAllEmployees")]
        [Authorize(Roles = "admin")]
        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            var list = await _employeeRepo.GetAllAsync();
            return list.Adapt<IEnumerable<EmployeeDTO>>(_mapper.Config);
        }

        [HttpGet("{id:int}", Name="GetEmployeeById")]
        [Authorize(Roles = "admin")]
        public async Task<EmployeeDTO> GetByIdAsync(int id)
        {
            var entity = await _employeeRepo.GetByIdAsync(id);
            return _mapper.Map<EmployeeDTO>(entity);
        }
        [HttpGet("{email:alpha}", Name = "GetEmployeeByEmail")]
        [Authorize(Roles = "admin")]
        public async Task<EmployeeDTO> GetByEmailAsync(string email)
        {
            var entity = await _employeeRepo.GetByEmailAsync(email);
            return _mapper.Map<EmployeeDTO>(entity);
        }

        [HttpPost(Name = "AddEmployee")]
        [Authorize(Roles = "admin")]
        public async Task AddAsync(EmployeeDTO entity)
        {
            var obj = _mapper.Map<Employees>(entity);
           // obj.PasswordHash = _hashService.GetHash(entity.Password);
            await _employeeRepo.InsertAsync(obj);
        }
        [HttpPut(Name = "UpdateEmployee")]
        [Authorize(Roles = "admin, employee")]
        public async Task UpdateAsync(EmployeeDTO employee)
        {
            var entity = _mapper.Map<Employees>(employee);
            await _employeeRepo.UpdateAsync(entity);
        }

        [HttpDelete("{id:int}", Name = "DeleteEmployee")]
        [Authorize(Roles = "admin")]
        public async Task DeleteAsync(int id)
        {
            await _employeeRepo.DeleteAsync(id);
        }

    }
}
