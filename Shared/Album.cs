using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music_manager_starter.Shared
{
    public sealed class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[]? CoverImage { get; set; } // Store the album cover as a URL

        // Navigation property for the one-to-many relationship
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
