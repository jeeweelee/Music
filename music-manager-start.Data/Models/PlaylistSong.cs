using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music_manager_starter.Data.Models
{
public class PlaylistSong
{
    public Guid PlaylistId { get; set; }
    public Playlist? Playlist { get; set; }
    
    public Guid SongId { get; set; }
    public Song? Song { get; set; }
}
}