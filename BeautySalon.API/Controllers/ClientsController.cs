using BeautySalon.Application.Repositories;
using BeautySalon.Application.Service.Interfaces;
using BeautySalon.Contracts.Dtos;
using BeautySalon.Infrastructure;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace BeautySalon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepo;
        private readonly IAppointmentRepository _appointmentRepo;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;

        public ClientsController(IClientRepository clientRepo, IMapper mapper, IHashService hashServ, IAppointmentRepository appointmentRepo)
        {
            _clientRepo = clientRepo;
            _mapper = mapper;
            _hashService = hashServ;
            _appointmentRepo = appointmentRepo;
        }

        [HttpGet(Name="GetAllClients")]
        [Authorize(Roles = "admin, client")]
        public async Task<IEnumerable<ClientDTO>> GetAllAsync()
        {
            var list = await _clientRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientDTO>>(list);
        }
        [Authorize(Roles = "admin, client")]
        [HttpGet("{id:int}",Name="GetClientById")]
        public async Task<ClientDTO> GetByIdAsync(int id)
        {
            var client = await _clientRepo.GetByIdAsync(id);
            return _mapper.Map<ClientDTO>(client);
        }
        [Authorize(Roles = "admin, client")]
        [HttpGet("{email:alpha}", Name = "GetClientByEmail")]
        public async Task<ClientDTO> GetByEmailAsync(string email)
        {
            var client = await _clientRepo.GetByEmailAsync(email);
            return _mapper.Map<ClientDTO>(client);
        }

        [HttpPost(Name = "AddClient")]
        [Authorize(Roles = "admin")]
        public async Task AddAsync(ClientDTO client)
        {
            var entity = _mapper.Map<Clients>(client);
            entity.PasswordHash = _hashService.GetHash(client.Password);
            await _clientRepo.InsertAsync(entity);
        }

        [HttpPut(Name = "UpdateClient")]
        [Authorize(Roles = "client")]
        public async Task UpdateAsync(ClientDTO client)
        {
            var entity = _mapper.Map<Clients>(client);
            await _clientRepo.UpdateAsync(entity);
        }

        [HttpDelete(Name = "DeleteClient")]
        [Authorize(Roles = "admin")]
        public async Task DeleteAsync(int id)
        {
            await _appointmentRepo.DeleteByClientIdAsync(id);
            await _clientRepo.DeleteAsync(id);
        }
    }
}
