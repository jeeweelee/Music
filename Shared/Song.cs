using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music_manager_starter.Shared
{
    public sealed class Song
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Guid AlbumId { get; set; }
        public Album Album { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; } 
    }
}
