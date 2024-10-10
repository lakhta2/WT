using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchTogetherDataAccess.Entities
{
    [Table("Albums")]
    public class AlbumEntity
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public Guid? ArtistId { get; set; }
        public UserEntity? Author { get; set; }
        public List<TrackEntity>? Tracks { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? AlbumArt { get; set; }
    }
}
