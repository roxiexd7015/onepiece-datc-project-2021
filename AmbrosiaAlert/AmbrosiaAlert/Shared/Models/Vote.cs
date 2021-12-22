using System;
using System.Collections.Generic;

namespace AmbrosiaAlert.Shared.Models
{
    public partial class Vote
    {
        public Guid? Id { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; }
        public Guid LocationId { get; set; }
        public DateTime AddedAt { get; set; }

        public virtual Location Location { get; set; }
        public virtual VoteType TypeNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
