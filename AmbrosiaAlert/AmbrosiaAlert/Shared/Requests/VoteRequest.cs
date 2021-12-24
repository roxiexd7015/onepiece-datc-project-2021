using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbrosiaAlert.Shared.Requests
{
    public class VoteRequest
    {
        public Guid LocationId { get; set; }
        public int VoteType { get; set; }
    }
}
