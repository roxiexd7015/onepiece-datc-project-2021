using AmbrosiaAlert.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbrosiaAlert.Domain
{
    public static class LocationDomain
    {
        public static Location CreateLocation(int addedBy, decimal latitude, decimal longitude)
        {
            var location = new Location()
            {
                AddedBy = addedBy,
                Latitude = latitude,
                Longitude = longitude,
                AddedAt = DateTime.UtcNow
            };

            return location;
        }
    }
}
