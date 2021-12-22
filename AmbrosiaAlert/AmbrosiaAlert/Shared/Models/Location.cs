using System;
using System.Collections.Generic;

namespace AmbrosiaAlert.Shared.Models
{
    public partial class Location
    {
        public Location()
        {
            Votes = new HashSet<Vote>();
        }

        public Guid Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime AddedAt { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
