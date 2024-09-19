using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WatchTogetherCore.Models
{
    public class Translation
    {
        public Guid id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public DateTime HadBroadcastedAt { get; set; }
    }
}
