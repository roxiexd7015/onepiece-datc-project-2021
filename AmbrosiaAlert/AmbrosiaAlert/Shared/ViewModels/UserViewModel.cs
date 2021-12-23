using AmbrosiaAlert.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbrosiaAlert.Shared.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(User model)
        {
            Id = model.Id;
            Username = model.Username;
            Email = model.Email;
            IsAdmin = model.IsAdmin;
            RegisteredAt = model.RegisteredAt;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}
