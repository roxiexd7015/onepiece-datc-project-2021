using AmbrosiaAlert.Domain;
using AmbrosiaAlert.Shared.Models;
using AmbrosiaAlert.Shared.Requests;
using AmbrosiaAlert.Shared.Settings;
using AmbrosiaAlert.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AmbrosiaAlert.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AmbrosiaAlertContext _context;
        private readonly PassSettings _settings;

        public UserController(AmbrosiaAlertContext context, PassSettings settings, IConfiguration config)
        {
            _context = context;
            _settings = settings;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.FirstOrDefault(a => a.Id.ToString() == userId);
            var response = user switch
            {
                User u => Ok(new UserViewModel(u)),
                _ => (IActionResult)BadRequest() //should never happen
            };
            return response;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest request)
        {
            var user = _context.Users.FirstOrDefault(a => a.Username == request.Username.Trim());
            if (user is null)
                return BadRequest("username or password are incorrect");
            if (!UserDomain.CheckPassword(request.Password, user.Password, _settings))
                return BadRequest("username or password are incorrect");

            var token = UserDomain.GetAccessToken(user, _config.GetValue<string>("JwtSecret"));
            return Ok(token);
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (_context.Users.Any(a => a.Username == request.Username.Trim()))
                return BadRequest("username already in use");
            if (_context.Users.Any(a => a.Email == request.Email.Trim()))
                return BadRequest("email already in use");

            var hashedPass = UserDomain.HashPassword(request.Password, _settings);
            var user = UserDomain.CreateUser(request.Username, request.Email, hashedPass, false);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
