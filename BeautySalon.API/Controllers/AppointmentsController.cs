using BeautySalon.Application.Repositories;
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
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepo;
        private readonly IMapper _mapper;

        public AppointmentsController(IAppointmentRepository appointmentRepo, IMapper mapper)
        {
            _appointmentRepo = appointmentRepo;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetAllAppointments")]
        [Authorize(Roles = "admin, client, employee")]
        public async Task<IEnumerable<AppointmentDTO>> GetAllAsync()
        {
            var list = await _appointmentRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<AppointmentDTO>>(list);
        }
        [HttpGet("{id:int}", Name = "GetAppointmentById")]
        [Authorize(Roles = "admin")]
        public async Task<AppointmentDTO> GetByIdAsync(int id)
        {
            var entity = await _appointmentRepo.GetByIdAsync(id);
            return _mapper.Map<AppointmentDTO>(entity);
        }
        [HttpPost(Name = "AddAppointment")]
        [Authorize(Roles = "admin")]
        public async Task AddAsync(AppointmentDTO entity)
        {
            var obj = _mapper.Map<Appointments>(entity);
            await _appointmentRepo.InsertAsync(obj);
        }
        [HttpPut(Name = "UpdateAppointment")]
        [Authorize(Roles = "admin")]
        public async Task UpdateAsync(AppointmentDTO entity)
        {
            var obj = _mapper.Map<Appointments>(entity);
            await _appointmentRepo.UpdateAsync(obj);
        }
        [HttpDelete(Name = "DeleteAppointment")]
        [Authorize(Roles = "admin")]
        public async Task DeleteAsync(int id)
        {
            await _appointmentRepo.DeleteAsync(id);
        }
    }
}
