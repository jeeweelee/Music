using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly DataDbContext _context;

        public PlaylistController(DataDbContext context)
        {
            _context = context;
        }

        [HttpGet] //Get all playlist
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            return await _context.Playlists.ToListAsync();
        }

        [HttpPost] //Add playlist
        public async Task<ActionResult<Playlist>> AddPlaylist(Playlist playlist)
        {
            
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync(); 

            return CreatedAtAction(nameof(GetPlaylists), new { id = playlist.Id }, playlist);
        }
    [HttpPut("{id}")] //Edit a playlist by ID
        public async Task<IActionResult> UpdatePlaylistName(Guid id, [FromBody] Playlist playlist)
        {
            var existingPlaylist = await _context.Playlists.FindAsync(id);

            if (existingPlaylist == null)
            {
                return NotFound(new { Message = $"Playlist with ID {id} not found." });
            }

            existingPlaylist.Name = playlist.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred while updating the playlist: {ex.Message}" });
            }

            return Ok(new { Message = $"Playlist name updated to '{existingPlaylist.Name}'." });
        }


        [HttpDelete("{id}")] //Delete Playlist
        public async Task<IActionResult> DeletePlaylist(Guid id)
        {
            var playlist = await _context.Playlists.FindAsync(id);

            if (playlist == null)
            {
                return NotFound(new { Message = $"Playlist with ID {id} not found." });
            }

            _context.Playlists.Remove(playlist);

            await _context.SaveChangesAsync();
            return Ok(new { Message = $"Playlist with ID {id} has been deleted." });
        }

        [HttpGet("{id}")] //Get Songs in playlist
        public async Task<ActionResult<IEnumerable<Song>>> GetSongsInPlaylist(Guid id)
        {
            var playlist = await _context.Playlists
            .Include(p => p.PlaylistSongs) 
            .ThenInclude(ps => ps.Song)    
            .FirstOrDefaultAsync(p => p.Id == id);

        if (playlist == null)
        {
            return NotFound(new { Message = $"Playlist with ID {id} not found." });
        }

        var songs = playlist.PlaylistSongs.Select(ps => ps.Song).ToList();

        return Ok(songs);
        }

    }
}