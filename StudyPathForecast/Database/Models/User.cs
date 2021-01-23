using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyPathForecast.Database.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
            CreatedAt = DateTime.UtcNow;
        }

        public User(string username, string password, string email, DateTime createdAt)
        {
            Username = username;
            Password = password;
            Email = email;
            CreatedAt = createdAt;
        }
    }
}