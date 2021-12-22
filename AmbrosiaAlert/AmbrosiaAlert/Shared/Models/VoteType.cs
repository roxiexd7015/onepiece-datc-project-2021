using System;
using System.Collections.Generic;

namespace AmbrosiaAlert.Shared.Models
{
    public partial class VoteType
    {
        public VoteType()
        {
            Votes = new HashSet<Vote>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
