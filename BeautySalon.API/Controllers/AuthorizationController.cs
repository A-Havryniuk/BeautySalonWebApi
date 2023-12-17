using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BeautySalon.Application.Repositories;
using BeautySalon.Application.Service.Interfaces;
using BeautySalon.Contracts.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace BeautySalon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHashService _hashService;
        private readonly IClientRepository _clientRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAdminRepository _adminRepository;

        public AuthorizationController(IConfiguration configuration, IHashService hashService, IClientRepository clientRepository, IEmployeeRepository employeeRepository, IAdminRepository adminRepository)
        {
            _configuration = configuration;
            _hashService = hashService;
            _clientRepository = clientRepository;
            _employeeRepository = employeeRepository;
            _adminRepository = adminRepository;
        }

        
        private string GetToken(string email, string role)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("Token:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration.GetSection("TokenInfo:Lifetime").Value)),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }


        [SwaggerResponse(
            StatusCodes.Status200OK,
            "Authorized successfully",
            typeof(TokenDTO)
        )]
        [SwaggerResponse(
            StatusCodes.Status400BadRequest,
            "Validation not passed",
            typeof(ValidationProblemDetails)
        )]
        [HttpPost]
        [Route("/login-admin")]
        public async Task<ActionResult<TokenDTO>> AdminLoginAsync(LoginDTO entity)
        {
            var admin = await _adminRepository.GetByEmailAsync(entity.Email);
            if (admin == null)
            {
                return ValidationProblem("Admin not found");
            }

            if (!_hashService.VerifyHash(entity.Password, admin.PasswordHash))
            {
                return ValidationProblem("Password is wrong");
            }

            var token = GetToken(entity.Email, "admin");
            return Ok(new TokenDTO()
            {
                Id = admin.Id,
                Token = token
            });
        }
        [HttpPost]
        [Route("/login-employee")]
        public async Task<ActionResult<string>> EmployeeLoginAsync(LoginDTO entity)
        {
            var employee = await _employeeRepository.GetByEmailAsync(entity.Email);
            if (employee == null)
            {
                return Unauthorized("Employee not found");
            }

            if (!_hashService.VerifyHash(entity.Password, employee.PasswordHash))
            {
                return Unauthorized("Password is wrong");
            }

            var token = GetToken(entity.Email, "employee");
            return Ok(token);
        }
        [HttpPost]
        [Route("/login-client")]
        public async Task<ActionResult<string>> ClientLoginAsync(LoginDTO entity)
        {
            var client = await _clientRepository.GetByEmailAsync(entity.Email);
            if (client == null)
            {
                return Unauthorized("Client not found");
            }

            if (!_hashService.VerifyHash(entity.Password, client.PasswordHash))
            {
                return Unauthorized("Password is wrong");
            }

            var token = GetToken(entity.Email, "client");
            return Ok(token);
        }
    }
}
