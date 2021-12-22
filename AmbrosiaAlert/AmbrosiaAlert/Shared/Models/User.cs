using System;
using System.Collections.Generic;

namespace AmbrosiaAlert.Shared.Models
{
    public partial class User
    {
        public User()
        {
            Votes = new HashSet<Vote>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime RegisteredAt { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
