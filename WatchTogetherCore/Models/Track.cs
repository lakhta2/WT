using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchTogetherCore.Models
{
    public class Track
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public string? Album { get; set; }
        public Guid AlbumId { get; set; }
        public Album? AlbumRefference { get; set; }
        public Guid? AuthorId { get; set; }
        public DateTime RealeseDate { get; set; }
        public string? FilePath { get; set; }
        public string? CoverFilePath { get; set; }
        public string? AnotherFilePath { get; set; }

    }
}
