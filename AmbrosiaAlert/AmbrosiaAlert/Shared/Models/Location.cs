using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmbrosiaAlert.Shared.Models
{
    public partial class Location
    {
        public Location()
        {
            Votes = new HashSet<Vote>();
        }

        public Guid? Id { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N6}")]
        public decimal Latitude { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N6}")]
        public decimal Longitude { get; set; }
        public DateTime AddedAt { get; set; }
        public int AddedBy { get; set; }

        public virtual User AddedByNavigation { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
