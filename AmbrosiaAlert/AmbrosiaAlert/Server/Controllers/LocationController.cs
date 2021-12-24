using AmbrosiaAlert.Domain;
using AmbrosiaAlert.Shared.Models;
using AmbrosiaAlert.Shared.Requests;
using AmbrosiaAlert.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AmbrosiaAlert.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly AmbrosiaAlertContext _context;

        public LocationController(AmbrosiaAlertContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var location = _context.Locations
                .Include(a => a.AddedByNavigation)
                .Include(a => a.Votes)
                .ThenInclude(a => a.TypeNavigation)
                .FirstOrDefault(a => a.Id == id);

            var response = location switch
            {
                Location l => Ok(new LocationViewModel(l)),
                _ => (IActionResult)NotFound()
            };
            return response;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() //TODO: make based on distance
        {
            var locations = _context.Locations
                .Include(a => a.AddedByNavigation)
                .Include(a => a.Votes)
                .ThenInclude(a => a.TypeNavigation)
                .Select(a => new LocationViewModel(a));
            return Ok(locations);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddLocationRequest request) //TODO: check proximity
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var location = LocationDomain.CreateLocation(int.Parse(userId), request.Latitude, request.Longitude);
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
