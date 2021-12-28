using AmbrosiaAlert.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

        [JsonConstructor]
        public UserViewModel(int id, string username, string email, bool isAdmin, DateTime registeredAt)
        {
            Id = id;
            Username = username;
            Email = email;
            IsAdmin = isAdmin;
            RegisteredAt = registeredAt;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}
