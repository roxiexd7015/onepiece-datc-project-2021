using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbrosiaAlert.Shared.Requests
{
    public class RegisterRequest
    {
        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
