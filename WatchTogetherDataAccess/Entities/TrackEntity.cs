using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchTogetherDataAccess.Entities
{
    [Table("Tracks")]
    public class TrackEntity
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public string? Album { get; set; }
        public Guid? AlbumId { get; set; }
        public AlbumEntity? AlbumReference { get; set; }
        public Guid? AuthorId { get; set; }
        public UserEntity? Author { get; set; }
        public DateTime RealeseDate { get; set; }
        public string? FilePath { get; set; }
        public string? CoverFilePath { get; set; }
        public string? AnotherFilePath { get; set; }

    }
}
