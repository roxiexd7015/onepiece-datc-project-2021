using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbrosiaAlert.Shared.Settings
{
    public class PassSettings
    {
        public int Iterations { get; set; }
        public int SaltSize { get; set; }
        public int KeySize { get; set; }
    }
}
