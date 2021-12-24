using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbrosiaAlert.Shared.Requests
{
    public class AddLocationRequest
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
