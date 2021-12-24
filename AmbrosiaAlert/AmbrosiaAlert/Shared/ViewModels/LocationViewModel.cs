using AmbrosiaAlert.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbrosiaAlert.Shared.ViewModels
{
    public class LocationViewModel
    {
        public LocationViewModel(Location model)
        {
            Id = model.Id.Value;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
            AddedAt = model.AddedAt;
            AddedBy = new UserViewModel(model.AddedByNavigation);
            VoteCount = model.Votes.Select(a => a.TypeNavigation.Value).Sum();
        }

        public Guid Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime AddedAt { get; set; }
        public int VoteCount { get; set; }
        public UserViewModel AddedBy { get; set; }
    }
}
