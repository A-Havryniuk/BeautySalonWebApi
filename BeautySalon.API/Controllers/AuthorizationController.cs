using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BeautySalon.Application.Repositories;
using BeautySalon.Application.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
    }
}
