using AmbrosiaAlert.Domain;
using AmbrosiaAlert.Shared.Models;
using AmbrosiaAlert.Shared.Requests;
using AmbrosiaAlert.Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AmbrosiaAlert.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VotingController : ControllerBase
    {
        private readonly AmbrosiaAlertContext _context;

        public VotingController(AmbrosiaAlertContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTypes()
        {
            var types =_context.VoteTypes.Select(a => new VoteTypeViewModel(a));
            return Ok(types);
        }

        [HttpPost]
        public async Task<IActionResult> Vote([FromBody] VoteRequest request)
        {            
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var oldVote = _context.Votes.FirstOrDefault(a =>
                a.UserId.ToString() == userId &&
                a.LocationId == request.LocationId &&
                a.Type == request.VoteType);

            if (oldVote is null)
            {
                var vote = VotingDomain.CreateVote(int.Parse(userId), request.LocationId, request.VoteType);
                _context.Votes.Add(vote);
            }
            else
            {
                _context.Remove(oldVote);
            }
            
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
