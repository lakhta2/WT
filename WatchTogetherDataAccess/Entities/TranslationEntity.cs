using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WatchTogetherDataAccess.Entities
{
    [Table("Translations")]
    public class TranslationEntity
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid? UserId { get; set; }
        public UserEntity? User { get; set; }
        public DateTime HadBroadcastedAt { get; set; }
    }
}
