using AmbrosiaAlert.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbrosiaAlert.Domain
{
    public static class VotingDomain
    {
        public static Vote CreateVote(int userId, Guid locationId, int typeId)
        {
            var vote = new Vote()
            {
                LocationId = locationId,
                AddedAt = DateTime.Now,
                UserId = userId,
                Type = typeId
            };

            return vote;
        }
    }
}
