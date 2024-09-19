using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchTogetherCore.Models
{
    public class Album
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public Guid ArtistId { get; set; }
        public User? Author { get; set; }
        public List<Track>? Tracks { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? AlbumArt { get; set; }
    }
}
