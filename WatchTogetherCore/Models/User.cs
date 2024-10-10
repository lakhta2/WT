using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTogetherDataAccess.Repositories;

namespace WatchTogetherCore.Models
{
    public class User
    {
        public const int MAX_USERNAME_LENGHT = 250;

        //Special ParametrLess Constructor for creating Api Identity Endpoints;
        public User() { }
        private User(Guid id, string userName, string description, decimal hours, string email, string password_hash)
        {
            Id = id;
            UserName = userName;
            //Email = email;
            //PasswordHash = password_hash;
            Description = description;
            Hours = hours;
        }
        private User(string userName, string email, string password_hash)
        {
            UserName = userName;
            //Email = email;
            //PasswordHash = password_hash;
        }
        private User(Guid id, string userName, string description, decimal hours)
        {
            Id = id;
            UserName = userName;
            Description = description;
            Hours = hours;
        }
        public Guid Id { get; }
        public string UserName { get; private set; } //= string.Empty;
        //public new string Email { get; private set;  } = string.Empty;
        //public new string PasswordHash { get; } = string.Empty;
        public List<Album> Albums { get; set; } = [];
        public List<Track> Tracks { get; set; } = [];
        public List<Translation> Translations { get; set; } = [];
        public string Description { get;  } = string.Empty;
        public decimal Hours { get; }
        public string? AvatarPictureURL { get; set; }
        public string? BackGroundURL { get; set; }
        public static (User user, string Error) Create(Guid id, string userName, string description, decimal hour, string email, string password_hash)
        {
            var error = string.Empty;

            if(string.IsNullOrEmpty(userName) || userName.Length > MAX_USERNAME_LENGHT)
            {
                error = "Username is too long or not declared";
            }

            var user = new User(id, userName, description, hour, email, password_hash);

            return (user, error);
        }
        public static (User user, string Error) Create(Guid id, string userName, string description, decimal hour)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(userName) || userName.Length > MAX_USERNAME_LENGHT)
            {
                error = "Username is too long or not declared";
            }

            var user = new User(id, userName, description, hour);

            return (user, error);
        }
        public static (User user, string Error) Register(Guid id, string userName, string email, string password_hash)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(userName) || userName.Length > MAX_USERNAME_LENGHT)
            {
                error = "Username is too long or not declared";
            }

            var user = new User(userName, email, password_hash);

            return (user, error);
        }

    }
}
