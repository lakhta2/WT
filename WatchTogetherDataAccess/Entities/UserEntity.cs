using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchTogetherDataAccess.Entities
{
    public class UserEntity : IdentityUser<Guid>
    {
        //public Guid Id { get; set; }
        //public new string UserName { get; set; }
        public string Description { get; set; } = String.Empty;
        public List<AlbumEntity> Albums { get; set; } = [];
        public List<TrackEntity> Tracks { get; set; } = [];
        public List<TranslationEntity> Translations { get; set; } = [];
        public decimal Hours { get; set; } = 0;
        public string? AvatarPictureURL { get; set; }
        public string? BackGroundURL { get; set; }
        //public new string? Email { get; set; } 
        //public new string? PasswordHash { get; set; }
        public UserEntity()
        {
            
        }
    }
}
