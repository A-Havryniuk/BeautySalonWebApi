using BeautySalon.Application.Repositories;
using BeautySalon.Contracts.Dtos;
using BeautySalon.Infrastructure;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BeautySalon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepo;
        private readonly IMapper _mapper;

        public ClientsController(IClientRepository clientRepo, IMapper mapper)
        {
            _clientRepo = clientRepo;
            _mapper = mapper;
        }

        [HttpGet(Name="GetAllClients")]
        public async Task<IEnumerable<ClientDTO>> GetAllAsync()
        {
            var list = await _clientRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientDTO>>(list);
        }

        [HttpGet("{id:int}",Name="GetClientById")]
        public async Task<ClientDTO> GetByIdAsync(int id)
        {
            var client = await _clientRepo.GetByIdAsync(id);
            return _mapper.Map<ClientDTO>(client);
        }

        [HttpGet("{email:alpha}", Name = "GetClientByEmail")]
        public async Task<ClientDTO> GetByEmailAsync(string email)
        {
            var client = await _clientRepo.GetByEmailAsync(email);
            return _mapper.Map<ClientDTO>(client);
        }

        [HttpPost(Name = "AddClient")]
        public async Task AddAsync(ClientDTO client)
        {
            var entity = _mapper.Map<Clients>(client);
            await _clientRepo.InsertAsync(entity);
        }

        [HttpPut(Name = "UpdateClient")]
        public async Task UpdateAsync(ClientDTO client)
        {
            var entity = _mapper.Map<Clients>(client);
            await _clientRepo.UpdateAsync(entity);
        }

        [HttpDelete(Name = "DeleteClient")]
        public async Task DeleteAsync(int id)
        {
            await _clientRepo.DeleteAsync(id);
        }
    }
}
